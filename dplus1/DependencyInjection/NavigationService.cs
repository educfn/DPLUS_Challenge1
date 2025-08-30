
namespace dplus1.DependencyInjection;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    private INavigation Navigation
        => Application.Current?.MainPage?.Navigation
            ?? throw new InvalidOperationException("Navigation not available");

    public Task PushAsync<TPage>() where TPage : Page
    {
        return Navigation.PushAsync(_services.GetRequiredService<TPage>());
    }

    public Task PopAsync()
    {
        return Navigation.PopAsync();
    }
}
