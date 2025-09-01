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
        CommandModifyClient = new AsyncRelayCommand(ModifyClient, AsyncRelayCommandOptions.None);
    }

    public ICommand CommandAddClient { get; }
    public ICommand CommandModifyClient { get; }
    public ObservableCollection<Client> AllClients { get; }

    private async Task AddClient()
    {
        await this.navigationService.PushAsync<ClientView>();
    }

    private async Task ModifyClient()
    {
        await this.navigationService.PushAsync<ClientView>();
    }
}
