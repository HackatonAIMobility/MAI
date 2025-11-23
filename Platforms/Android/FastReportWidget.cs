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
    [BroadcastReceiver(Name = "com.equipoazul.mai.FastReportWidget", Label = "Fast Report", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE", "com.equipoazul.mai.ACTION_REPORT_OK", "com.equipoazul.mai.ACTION_REPORT_NOT_OK" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/fast_report_widget_info")]
    public class FastReportWidget : AppWidgetProvider
    {
        public const string ACTION_REPORT_OK = "com.equipoazul.mai.ACTION_REPORT_OK";
        public const string ACTION_REPORT_NOT_OK = "com.equipoazul.mai.ACTION_REPORT_NOT_OK";

        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            // Perform this loop for each App Widget that belongs to this provider
            foreach (int appWidgetId in appWidgetIds)
            {
                UpdateAppWidget(context, appWidgetManager, appWidgetId);
            }
        }

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
