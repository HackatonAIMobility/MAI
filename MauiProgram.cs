using Microsoft.Extensions.Logging;
using BlazorBootstrap;
using MAI.Models;
using MAI.Services;
using Plugin.LocalNotification;

namespace MAI;

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
