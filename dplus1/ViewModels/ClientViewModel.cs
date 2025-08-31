using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using dplus1.DependencyInjection;

namespace dplus1.ViewModels;

public class ClientViewModel
{
    private readonly INavigationService navigationService;

    public ClientViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        CommandNavigateBack = new AsyncRelayCommand(NavigateBack,AsyncRelayCommandOptions.None);
    }

    public ICommand CommandNavigateBack { get; }

    public async Task NavigateBack()
    {
        await navigationService.PopAsync();
    }
}
