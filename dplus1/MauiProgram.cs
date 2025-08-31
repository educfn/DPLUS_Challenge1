using dplus1.DependencyInjection;
using dplus1.ViewModels;
using dplus1.Views;
using Microsoft.Extensions.Logging;

namespace dplus1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		builder.Services.AddTransient<ClientView>();
		builder.Services.AddTransient<ClientViewModel>();

		builder.Services.AddTransient<ClientsListView>();
		builder.Services.AddSingleton<ClientsListViewModel>();

		return builder.Build();
	}
}
