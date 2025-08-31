using dplus1.Views;

namespace dplus1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var mainPage = activationState?.Context.Services.GetService<ClientsListView>();
		if (mainPage == null)
			throw new InvalidOperationException("ClientsListView is not registered in the DI container.");

		var window = new Window
		{
			Page = new NavigationPage(mainPage)
		};

		return window;
	}
}