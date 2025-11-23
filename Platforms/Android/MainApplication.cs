using Android.App;
using Android.Runtime;

namespace MAI;

/// <summary>
/// Represents the main application class for the Android platform.
/// This class initializes the .NET MAUI application and handles Android-specific application lifecycle events.
/// </summary>
[Application]
public class MainApplication : MauiApplication
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainApplication"/> class.
    /// This constructor is required for Android application instantiation.
    /// </summary>
    /// <param name="handle">The pointer to the Android JNI object.</param>
    /// <param name="ownership">Specifies whether the JNI reference is owned by the runtime.</param>
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

    /// <summary>
    /// Creates and configures the .NET MAUI application.
    /// This method delegates to <see cref="MauiProgram.CreateMauiApp"/> to build the application instance.
    /// </summary>
    /// <returns>The configured <see cref="MauiApp"/> instance.</returns>
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
