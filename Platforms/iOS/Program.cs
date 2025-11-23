using ObjCRuntime;
using UIKit;

namespace MAI;

/// <summary>
/// Entry point for the iOS application.
/// This class is responsible for bootstrapping the application on iOS devices.
/// </summary>
public class Program
{
	/// <summary>
	/// The main entry point of the application for iOS.
	/// </summary>
	/// <param name="args">Command-line arguments passed to the application.</param>
	static void Main(string[] args)
	{
		// if you want to use a different Application Delegate class from "AppDelegate"
		// you can specify it here.
		UIApplication.Main(args, null, typeof(AppDelegate));
	}
}
