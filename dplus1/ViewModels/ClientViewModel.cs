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
        CommandSave = new AsyncRelayCommand(Save,AsyncRelayCommandOptions.None);
        CommandCancel = new AsyncRelayCommand(Cancel,AsyncRelayCommandOptions.None);
    }

    public Client Client{ get; set;} = new Client();

    public ICommand CommandSave { get; }
    public ICommand CommandCancel { get; }

    public async Task Save()
    {
        clientList.AllClients.Add(Client);
        this.Client = new();
        await navigationService.PopAsync();
    }

    public async Task Cancel()
    {
        this.Client = new();
        await navigationService.PopAsync();
    }
}
