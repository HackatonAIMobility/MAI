using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MAI.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// This class is the entry point for the Windows UI (WinUI) application, inheriting
/// from <see cref="MauiWinUIApplication"/> to integrate .NET MAUI functionalities.
/// </summary>
public partial class App : MauiWinUIApplication
{
	/// <summary>
	/// Initializes the singleton application object. This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
		this.InitializeComponent();
	}

    /// <summary>
    /// Creates and configures the .NET MAUI application.
    /// This method delegates to <see cref="MauiProgram.CreateMauiApp"/> to build the application instance.
    /// </summary>
    /// <returns>The configured <see cref="MauiApp"/> instance.</returns>
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

