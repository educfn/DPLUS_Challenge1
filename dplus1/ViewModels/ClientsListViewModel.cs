using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace dplus1.ViewModels;

public class ClientsListViewModel
{
    public ClientsListViewModel()
    {
        CommandNavigateToClientView = new AsyncRelayCommand(NavigateToClient, AsyncRelayCommandOptions.None);
    }

    public ICommand CommandNavigateToClientView { get; }

    private Task NavigateToClient()
    {
        return Task.CompletedTask;
    }
}
