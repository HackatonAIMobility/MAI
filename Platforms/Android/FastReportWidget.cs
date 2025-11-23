using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;
using Android.Graphics;
using System.Threading.Tasks;
using MAI.Services;
using Microsoft.Maui.Platform;

namespace MAI.Platforms.Android
{
    /// <summary>
    /// Implements an Android App Widget for fast incident reporting.
    /// This widget allows users to quickly report whether their travel was successful or not
    /// with a single tap, leveraging geolocation to identify the nearest metro station.
    /// </summary>
    [BroadcastReceiver(Name = "com.equipoazul.mai.FastReportWidget", Label = "Fast Report", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE", "com.equipoazul.mai.ACTION_REPORT_OK", "com.equipoazul.mai.ACTION_REPORT_NOT_OK" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/fast_report_widget_info")]
    public class FastReportWidget : AppWidgetProvider
    {
        /// <summary>
        /// Action string for reporting a successful travel incident from the widget.
        /// </summary>
        public const string ACTION_REPORT_OK = "com.equipoazul.mai.ACTION_REPORT_OK";
        /// <summary>
        /// Action string for reporting an unsuccessful travel incident from the widget.
        /// </summary>
        public const string ACTION_REPORT_NOT_OK = "com.equipoazul.mai.ACTION_REPORT_NOT_OK";

        /// <summary>
        /// Called when the App Widget is to be updated.
        /// This method is called to update the App Widget's UI and set up event handlers.
        /// </summary>
        /// <param name="context">The <see cref="Context"/> in which this receiver is running.</param>
        /// <param name="appWidgetManager">The <see cref="AppWidgetManager"/> instance for the current App Widget provider.</param>
        /// <param name="appWidgetIds">An array of IDs of the App Widgets to be updated.</param>
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            // Perform this loop for each App Widget that belongs to this provider
            foreach (int appWidgetId in appWidgetIds)
            {
                UpdateAppWidget(context, appWidgetManager, appWidgetId);
            }
        }

        /// <summary>
        /// Updates a single instance of the Fast Report widget.
        /// This method sets up the layout and attaches pending intents to the buttons
        /// for reporting successful or unsuccessful travel incidents.
        /// </summary>
        /// <param name="context">The <see cref="Context"/> in which this receiver is running.</param>
        /// <param name="appWidgetManager">The <see cref="AppWidgetManager"/> instance for the current App Widget provider.</param>
        /// <param name="appWidgetId">The ID of the specific App Widget instance to update.</param>
        public static void UpdateAppWidget(Context context, AppWidgetManager appWidgetManager, int appWidgetId)
        {
            var views = new RemoteViews(context.PackageName, Resource.Layout.widget_fast_report);

            // Set up the click listener for the "OK" button
            var okIntent = new Intent(context, typeof(FastReportWidget));
            okIntent.SetAction(ACTION_REPORT_OK);
            okIntent.PutExtra(AppWidgetManager.ExtraAppwidgetId, appWidgetId);
            var okPendingIntent = PendingIntent.GetBroadcast(context, appWidgetId, okIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);
            views.SetOnClickPendingIntent(Resource.Id.btn_ok, okPendingIntent);

            // Set up the click listener for the "Not OK" button
            var notOkIntent = new Intent(context, typeof(FastReportWidget));
            notOkIntent.SetAction(ACTION_REPORT_NOT_OK);
            notOkIntent.PutExtra(AppWidgetManager.ExtraAppwidgetId, appWidgetId);
            var notOkPendingIntent = PendingIntent.GetBroadcast(context, appWidgetId + 1, notOkIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable); // Use a different request code
            views.SetOnClickPendingIntent(Resource.Id.btn_not_ok, notOkPendingIntent);

            // Instruct the widget manager to update the widget
            appWidgetManager.UpdateAppWidget(appWidgetId, views);
        }

        /// <summary>
        /// Called when an <see cref="Intent"/> is sent to this <see cref="BroadcastReceiver"/>.
        /// This method handles incoming intents, particularly those triggered by widget button clicks
        /// for reporting incidents. It initializes the MAUI app services if necessary and
        /// then delegates to <see cref="WidgetIncidentService"/> to report the incident.
        /// </summary>
        /// <param name="context">The <see cref="Context"/> in which this receiver is running.</param>
        /// <param name="intent">The <see cref="Intent"/> being received.</param>
        public override async void OnReceive(Context context, Intent intent)
        {
            base.OnReceive(context, intent);

            // Ensure MAUI app is initialized to access services
            if (MauiApplication.Current == null)
            {
                // If the MAUI app is not running, we need to start the main activity
                // to ensure services are initialized.
                var launchIntent = new Intent(context, typeof(MainActivity));
                launchIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask); // Clear any existing stack
                launchIntent.PutExtra("widget_action", intent.Action); // Pass the widget action
                launchIntent.PutExtra("appWidgetId", intent.GetIntExtra(AppWidgetManager.ExtraAppwidgetId, AppWidgetManager.InvalidAppwidgetId));
                context.StartActivity(launchIntent);
                return;
            }

            // ... rest of the code ...

            var widgetIncidentService = MauiApplication.Current.Services.GetService<WidgetIncidentService>();

            if (widgetIncidentService == null)
            {
                Console.WriteLine("WidgetIncidentService not found. Ensure it's registered in MauiProgram.cs");
                return;
            }

            bool isTravelSuccessful = false;
            if (intent.Action == ACTION_REPORT_OK)
            {
                isTravelSuccessful = true;
                Console.WriteLine("OK button clicked!");
            }
            else if (intent.Action == ACTION_REPORT_NOT_OK)
            {
                isTravelSuccessful = false;
                Console.WriteLine("Not OK button clicked!");
            }
            else
            {
                return; // Not our action
            }

            // Report the incident using the service
            await widgetIncidentService.ReportTravelIncident(isTravelSuccessful);
            Toast.MakeText(context, "Report sent!", ToastLength.Short)?.Show();

            // Optionally, update the widget UI to show a "Report Sent" message or similar.
            // For now, we'll keep it simple.
        }
    }
}
