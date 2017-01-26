using Android.App;
using Android.OS;
using System.Threading.Tasks;
using Firebase.Iid;


namespace firebasepush
{
    [Activity(Label = "fire base push", MainLauncher = true, Icon = "@drawable/icon" )]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            if (!GetString(Resource.String.google_app_id).Equals("Your app code"))
                //throw new System.Exception("Invalid Json file");
            Task.Run(() => {
                var instanceId = FirebaseInstanceId.Instance;
                instanceId.DeleteInstanceId();
                Android.Util.Log.Debug("TAG", "{0} {1}", instanceId.Token, instanceId.GetToken(GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope));
            });
           

        }
    }
}

