
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Proyectos1.Resources;

namespace Proyectos1
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        Usuario uactual = new Usuario();

        Button alex, goog, apple;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_home);
            instancias();
            acciones();

            // Create your application here
        }

        private void acciones()
        {
            alex.Click += Alex_Click;
            goog.Click += Goog_Click;
            apple.Click += Apple_Click;

        }

        private void Apple_Click(object sender, EventArgs e)
        {
            //cambiar el activiti al siguiente
            Intent i = new Intent(this, typeof(ActivityLista1));
            i.PutExtra("usuario", (Java.IO.ISerializable)uactual);
            i.PutExtra("OPCION", "APPLE");
            StartActivity(i);


        }

        private void Goog_Click(object sender, EventArgs e)
        {
            //cambiar el activiti al siguiente
            Intent i = new Intent(this, typeof(ActivityLista1));
            i.PutExtra("usuario", (Java.IO.ISerializable)uactual);
            i.PutExtra("OPCION", "google");
            StartActivity(i);
        }

        private void Alex_Click(object sender, EventArgs e)
        {
            //cambiar el activiti al siguiente
            Intent i = new Intent(this, typeof(ActivityLista1));
            i.PutExtra("usuario", (Java.IO.ISerializable)uactual);
            i.PutExtra("OPCION", "alexa");
            StartActivity(i);
        }

        private void instancias()
        {
            alex = FindViewById<Button>(Resource.Id.alex);
            goog = FindViewById<Button>(Resource.Id.goog);
            apple = FindViewById<Button>(Resource.Id.apple);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
