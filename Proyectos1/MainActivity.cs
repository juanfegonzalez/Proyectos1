using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace Proyectos1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity 
    {
        EditText user, pass;
        Button login, registro;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            //se hacen laas instancias de los botones
            user = FindViewById<EditText>(Resource.Id.user);
            pass = FindViewById<EditText>(Resource.Id.pass);
            login = FindViewById<Button>(Resource.Id.login);
            registro = FindViewById<Button>(Resource.Id.registro);
            //se dan las acciones que van a utilizar cada uno de ellos
            acciones();

        }

        private void acciones()
        {
            login.Click += (sender, e) =>
             {
                 Intent intent = new Intent(this, typeof(ActivityReg));
                 StartActivity(intent);

             };
            registro.Click += (sender, e) =>
            {
                Intent intent = new Intent(this,typeof(ActivityReg));
                StartActivity(intent);

            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}