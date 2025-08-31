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

        CommandNavigateToClientView = new AsyncRelayCommand(NavigateToClient, AsyncRelayCommandOptions.None);
    }

    public ICommand CommandNavigateToClientView { get; }
    public ObservableCollection<Client> AllClients { get; }

    private async Task NavigateToClient()
    {
        await this.navigationService.PushAsync<ClientView>();
    }
}
