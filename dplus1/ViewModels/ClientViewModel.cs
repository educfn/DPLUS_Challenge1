using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using dplus1.DependencyInjection;
using dplus1.Model;

namespace dplus1.ViewModels;

public class ClientViewModel
{
    private readonly INavigationService navigationService;
    private ClientsListViewModel clientList;

    public ClientViewModel(
        INavigationService navigationService,
        ClientsListViewModel clientList)
    {
        this.navigationService = navigationService;
        this.clientList = clientList;
        clientList.ClientViewModel = this;
        CommandSave = new AsyncRelayCommand(Save,AsyncRelayCommandOptions.None);
        CommandCancel = new AsyncRelayCommand(Cancel,AsyncRelayCommandOptions.None);
        CommandRemove = new AsyncRelayCommand(Remove,AsyncRelayCommandOptions.None);
    }

    public Client Client { get; set;} = new Client();
    public Client UnmodifiedClient { get; set;} = new Client();

    public ICommand CommandSave { get; }
    public ICommand CommandCancel { get; }
    public ICommand CommandRemove { get; }

    public async Task Save()
    {
        var newClient = new Client();

        if (Client.Equals(newClient) || Client.Equals(UnmodifiedClient)) return;

        if (!UnmodifiedClient.Equals(newClient))
        {
            clientList.AllClients.Remove(UnmodifiedClient);
        }

        clientList.AllClients.Add(Client);

        this.Client = new();
        this.UnmodifiedClient = new();
        await navigationService.PopAsync();
    }

    public async Task Remove()
    {
        clientList.AllClients.Remove(UnmodifiedClient);

        this.Client = new();
        this.UnmodifiedClient = new();
        await navigationService.PopAsync();
    }

    public async Task Cancel()
    {
        this.Client = new();
        this.UnmodifiedClient = new();
        await navigationService.PopAsync();
    }
}
