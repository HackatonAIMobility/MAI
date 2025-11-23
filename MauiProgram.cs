using Microsoft.Extensions.Logging;
using BlazorBootstrap;
using MAI.Models;
using MAI.Services;
using Plugin.LocalNotification;

namespace MAI;

/// <summary>
/// Provides the entry point for configuring and creating the MAUI application.
/// This class is responsible for setting up the application's services, fonts,
/// and integrating third-party libraries like Blazor and local notifications.
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Creates and configures the <see cref="MauiApp"/> for the application.
    /// This method registers all necessary services, sets up fonts, and enables
    /// developer tools for debugging in DEBUG mode.
    /// </summary>
    /// <returns>A configured <see cref="MauiApp"/> instance.</returns>
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
            .UseLocalNotification(); // Add this line

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddBlazorBootstrap();
        builder.Services.AddSingleton<MetroService>();
        builder.Services.AddMemoryCache();
        builder.Services.AddSingleton<WebSocketService>();
        builder.Services.AddSingleton<NotificationService>();
        builder.Services.AddSingleton<ReportStateService>();
        builder.Services.AddSingleton<WidgetIncidentService>(); // Add this line
        builder.Services.AddHttpClient();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
