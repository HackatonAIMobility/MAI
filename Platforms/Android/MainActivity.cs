using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MAI.Services;
using Android.Widget;
using Android.Appwidget;
using MAI.Platforms.Android;

namespace MAI;

/// <summary>
/// Main activity for the Android platform, serving as the entry point for the MAI application.
/// This activity handles the initial launch, theme application, and specific intents related to widgets,
/// such as widget configuration and direct actions from widgets.
/// </summary>
[Activity(
    Name = "com.equipoazul.mai.MainActivity", 
    Theme = "@style/Maui.SplashTheme", 
    MainLauncher = true, 
    Exported = true, 
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    /// <summary>
    /// Called when the activity is first created.
    /// This method sets up the activity, including handling widget configuration intents.
    /// </summary>
    /// <param name="savedInstanceState">If the activity is being re-initialized after
    ///     previously being shut down then this Bundle contains the data it most recently
    ///     supplied in <see cref="OnSaveInstanceState(Bundle)"/>.</param>
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Check if the app was started by the Widget Configuration request
        if (Intent?.Action == AppWidgetManager.ActionAppwidgetConfigure)
        {
            HandleWidgetConfiguration(Intent);
        }
    }

    /// <summary>
    /// This method is called when the activity receives a new <see cref="Intent"/>.
    /// It is used to process actions originating from the app widget, such as reporting incidents.
    /// </summary>
    /// <param name="intent">The new intent that was started for the activity.</param>
    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        
        if (intent.HasExtra("widget_action"))
        {
            HandleWidgetAction(intent);
        }
    }

    /// <summary>
    /// Handles the configuration process for an App Widget.
    /// This method is invoked when a user adds an app widget to their home screen and
    /// the widget requires configuration. It sets the result for the widget ID.
    /// </summary>
    /// <param name="intent">The intent that triggered the widget configuration, containing the App Widget ID.</param>
    private void HandleWidgetConfiguration(Intent intent)
    {
        // 1. Get the App Widget ID this configuration is for
        int appWidgetId = intent.GetIntExtra(AppWidgetManager.ExtraAppwidgetId, AppWidgetManager.InvalidAppwidgetId);

        if (appWidgetId != AppWidgetManager.InvalidAppwidgetId)
        {
            // 2. OPTIONAL: Initialize the widget UI here if needed 
            // (e.g., FastReportWidget.UpdateAppWidget(this, AppWidgetManager.GetInstance(this), appWidgetId);)

            // 3. Create the result intent
            Intent resultValue = new Intent();
            resultValue.PutExtra(AppWidgetManager.ExtraAppwidgetId, appWidgetId);

            // 4. Tell Android "Everything is OK, place the widget"
            SetResult(Result.Ok, resultValue);
            
            // 5. Close the activity so the user returns to the home screen to see the widget
            Finish(); 
        }
        else
        {
            // Invalid ID, cancel
            SetResult(Result.Canceled);
            Finish();
        }
    }

    /// <summary>
    /// Handles actions initiated from the app widget, specifically incident reporting.
    /// It retrieves the widget action, determines the success status of travel, and submits
    /// an incident report using the <see cref="WidgetIncidentService"/>.
    /// </summary>
    /// <param name="intent">The intent containing the widget action extra.</param>
    private async void HandleWidgetAction(Intent intent)
    {
        var widgetIncidentService = MauiApplication.Current.Services.GetService<WidgetIncidentService>();

        if (widgetIncidentService == null)
        {
            Console.WriteLine("WidgetIncidentService not found in MainActivity. Ensure it's registered in MauiProgram.cs");
            return;
        }

        string action = intent.GetStringExtra("widget_action");
        bool isTravelSuccessful = false;

        if (action == FastReportWidget.ACTION_REPORT_OK)
        {
            isTravelSuccessful = true;
            Console.WriteLine("OK button clicked from widget, processed in MainActivity!");
        }
        else if (action == FastReportWidget.ACTION_REPORT_NOT_OK)
        {
            isTravelSuccessful = false;
            Console.WriteLine("Not OK button clicked from widget, processed in MainActivity!");
        }
        else
        {
            return;
        }

        await widgetIncidentService.ReportTravelIncident(isTravelSuccessful);
        Toast.MakeText(this, "Report sent from widget!", ToastLength.Short)?.Show();

        // Optionally, you might want to navigate to a specific page or close the activity
        // if this was just a background action.
        // Finish(); 
    }
}
