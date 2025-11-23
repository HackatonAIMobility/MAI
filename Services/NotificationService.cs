using Plugin.LocalNotification;

namespace MAI.Services
{
    /// <summary>
    /// Provides functionality for displaying local notifications within the application.
    /// This service leverages the Plugin.LocalNotification library to create and show
    /// notifications with a given title and message.
    /// </summary>
    public class NotificationService
    {
        /// <summary>
        /// Displays a local notification to the user.
        /// The notification will be delivered immediately upon calling this method.
        /// </summary>
        /// <param name="title">The title of the notification.</param>
        /// <param name="message">The main message content of the notification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ShowNotification(string title, string message)
        {
            var request = new NotificationRequest
            {
                NotificationId = new Random().Next(), // Unique ID for the notification
                Title = title,
                Description = message,
                Schedule = new NotificationRequestSchedule
                {
                    // Deliver immediately
                    NotifyTime = DateTime.Now
                }
            };
            await LocalNotificationCenter.Current.Show(request);
        }
    }
}
