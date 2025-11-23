namespace MAI;

/// <summary>
/// Represents the main content page of the application.
/// This page typically serves as a container for the BlazorWebView
/// which hosts the Blazor-based user interface.
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// Calls <see cref="InitializeComponent"/> to load the XAML-defined UI.
    /// </summary>
	public MainPage()
	{
		InitializeComponent();
	}
}
