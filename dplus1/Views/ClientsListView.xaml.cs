using dplus1.ViewModels;

namespace dplus1.Views;

public partial class ClientsListView : ContentPage
{
    ClientsListViewModel vm;

	public ClientsListView(ClientsListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        this.vm = vm;
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        clientsCollection.SelectedItem = null;
    }

    private void Button_Released(object sender, EventArgs e)
    {
        vm.SaveClientsList.Execute(null);
    }
}
