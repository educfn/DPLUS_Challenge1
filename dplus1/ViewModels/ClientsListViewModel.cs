using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using dplus1.DependencyInjection;
using dplus1.Views;

namespace dplus1.ViewModels;

public class ClientsListViewModel
{
    private readonly INavigationService _navigationService;

    public ClientsListViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        CommandNavigateToClientView = new AsyncRelayCommand(NavigateToClient, AsyncRelayCommandOptions.None);
    }

    public ICommand CommandNavigateToClientView { get; }

    private async Task NavigateToClient()
    {
        await _navigationService.PushAsync<ClientView>();
    }
}
