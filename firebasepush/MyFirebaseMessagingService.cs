using Android.App;
using Android.Content;
using Firebase.Messaging;
using Android.Media;
using Android.Support.V7.App;

namespace firebasepush
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            var notification = message.GetNotification();
            var title = notification.Title;
            var body = notification.Body;

            SendNotification(title, body, message);
        }

        private void SendNotification(string Title , string Body , RemoteMessage oi)
        {
            
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetContentTitle(Title)
                .SetContentText(Body)
                .SetAutoCancel(false)
                .SetSound(defaultSoundUri)
                .SetPriority(1)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}