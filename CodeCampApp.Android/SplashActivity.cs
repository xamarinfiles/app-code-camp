
using Android.App;
using Android.OS;

namespace CodeCampApp.Droid
{
    [Activity(Icon = "@mipmap/icon", Theme = "@style/SplashScreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}