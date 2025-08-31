using dplus1.ViewModels;

namespace dplus1.Views;

public partial class ClientView : ContentPage
{
	public ClientView(ClientViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}