using Android.App;
using Android.Content;
using Android.OS;

namespace AppTiendaZ.Droid
{
    [Activity(Label = "Te Presto", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}