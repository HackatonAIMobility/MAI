using Foundation;

namespace MAI;

/// <summary>
/// The application delegate for iOS. This class is responsible for
/// handling application lifecycle events and creating the main MAUI app instance.
/// </summary>
[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    /// <summary>
    /// Creates and configures the .NET MAUI application.
    /// This method delegates to <see cref="MauiProgram.CreateMauiApp"/> to build the application instance.
    /// </summary>
    /// <returns>The configured <see cref="MauiApp"/> instance.</returns>
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
