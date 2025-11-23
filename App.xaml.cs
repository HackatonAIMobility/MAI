namespace MAI;

/// <summary>
/// Represents the main application class for the .NET MAUI application.
/// This class handles the application's lifecycle and initializes the main window.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// Calls <see cref="InitializeComponent"/> to load the XAML-defined resources and UI.
    /// </summary>
	public App()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Creates the main <see cref="Window"/> for the application.
    /// This method is overridden to set the initial content of the window to <see cref="MainPage"/>
    /// and assigns a title to the window.
    /// </summary>
    /// <param name="activationState">The <see cref="IActivationState"/> providing information about the activation event.</param>
    /// <returns>A new <see cref="Window"/> instance configured for the application.</returns>
	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new MainPage()) { Title = "MAI" };
	}
}
