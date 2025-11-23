using Plugin.LocalNotification;

namespace MAI.Services
{
    public class NotificationService
    {
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
