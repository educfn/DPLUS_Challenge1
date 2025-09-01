using CommunityToolkit.Mvvm.Input;
using dplus1.DependencyInjection;
using dplus1.Model;
using dplus1.Views;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Xml.Serialization;

namespace dplus1.ViewModels;

public class ClientsListViewModel
{
    private readonly INavigationService navigationService;
    string clientsfileName = Path.Combine(FileSystem.AppDataDirectory, "clients.txt");
    private ClientViewModel clientViewModel;

    public ClientsListViewModel(
        INavigationService navigationService,
        ClientViewModel clientViewModel)
    {
        this.navigationService = navigationService;
        this.clientViewModel = clientViewModel;
        this.clientViewModel.ClientListViewModel = this;
        AllClients = new ObservableCollection<Client>();
        CommandAddClient = new AsyncRelayCommand(AddClient, AsyncRelayCommandOptions.None);
        CommandSelectedClient = new AsyncRelayCommand<Client>(SelectedClient, AsyncRelayCommandOptions.None);
        SaveClientsList = new AsyncRelayCommand(SaveInstanceClients, AsyncRelayCommandOptions.None);
        InitialLoadClients();
        AllClients.CollectionChanged += OnClientsCollectionChanged;
    }

    public ICommand CommandAddClient { get; }
    public ICommand CommandSelectedClient { get; }
    public ICommand SaveClientsList { get; }
    public ObservableCollection<Client> AllClients { get; private set;}

    private async Task AddClient()
    {
        await this.navigationService.PushAsync<ClientView>();
    }

    private async Task SelectedClient(Client? client)
    {
        if (client == null) return;

        clientViewModel.Client = client.ToClone();
        clientViewModel.UnmodifiedClient = client.ToClone();
        await this.navigationService.PushAsync<ClientView>();
    }

    private void InitialLoadClients()
    { 
        var serializer = new XmlSerializer(typeof(ObservableCollection<Client>));

        if (!File.Exists(clientsfileName)) return;

        string xmlClientsString = File.ReadAllText(clientsfileName);

        using (TextReader reader = new StringReader(xmlClientsString))
        {
            var clientsList = (ObservableCollection<Client>?)serializer.Deserialize(reader);
            if (clientsList != null)
                AllClients = clientsList;
        }
    }

    private Task SaveInstanceClients()
    {
        var serializer = new XmlSerializer(typeof(ObservableCollection<Client>));

        using (TextWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, AllClients);
            string? xmlClientsString = writer.ToString();
            if (xmlClientsString != null)
                File.WriteAllText(clientsfileName, xmlClientsString);
            else throw new ArgumentNullException(nameof(xmlClientsString) + "is null");
        }

        return Task.CompletedTask;
    }

    private void OnClientsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        SaveInstanceClients();
    }
}
