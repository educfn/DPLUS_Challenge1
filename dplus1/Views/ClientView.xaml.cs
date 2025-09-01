using dplus1.ViewModels;

namespace dplus1.Views;

public partial class ClientView : ContentPage
{
	private ClientViewModel vm;

	public ClientView(ClientViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		this.vm = vm;
	}

	private async void RemoveClientButtonClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Attention", "Are you sure you want to delete?", "Yes", "No");

		if (answer)
			vm.CommandRemove.Execute(null);
    }
}