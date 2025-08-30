namespace dplus1.DependencyInjection;

public interface INavigationService
{
    Task PushAsync<TPage>() where TPage : Page;
    Task PopAsync();
}
