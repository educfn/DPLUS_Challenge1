using dplus1.ViewModels;

namespace dplus1.Views;

public partial class ClientsListView : ContentPage
{
	public ClientsListView(ClientsListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
