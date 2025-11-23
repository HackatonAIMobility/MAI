using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MAI;

/// <summary>
/// Entry point for the Tizen platform application.
/// This class initializes and runs the MAUI application on Tizen devices.
/// </summary>
class Program : MauiApplication
{
    /// <summary>
    /// Creates and configures the .NET MAUI application for the Tizen platform.
    /// This method delegates to <see cref="MauiProgram.CreateMauiApp"/> to build the application instance.
    /// </summary>
    /// <returns>The configured <see cref="MauiApp"/> instance.</returns>
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    /// <summary>
    /// The main entry point for the Tizen application.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the application.</param>
	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
