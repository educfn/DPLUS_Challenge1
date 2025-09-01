using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using dplus1.DependencyInjection;
using dplus1.Model;
using dplus1.Views;

namespace dplus1.ViewModels;

public class ClientsListViewModel
{
    private readonly INavigationService navigationService;
    

    public ClientsListViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        AllClients = new ObservableCollection<Client>();
        CommandAddClient = new AsyncRelayCommand(AddClient, AsyncRelayCommandOptions.None);
        CommandSelectedClient = new AsyncRelayCommand<Client>(SelectedClient, AsyncRelayCommandOptions.None);
    }

    public ICommand CommandAddClient { get; }
    public ICommand CommandSelectedClient { get; }
    public ObservableCollection<Client> AllClients { get; }
    public ClientViewModel ClientViewModel { get; set;}

    private async Task AddClient()
    {
        await this.navigationService.PushAsync<ClientView>();
    }

    private async Task SelectedClient(Client? client)
    {
        if (client == null) return;

        ClientViewModel.Client = client.ToClone();
        ClientViewModel.UnmodifiedClient = client.ToClone();
        await this.navigationService.PushAsync<ClientView>();
    }
}
