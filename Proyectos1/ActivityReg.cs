
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

using Android.Content;
using AlertDialog = Android.App.AlertDialog;


using Android.Views;


namespace Proyectos1
{
    [Activity(Label = "ActivityReg")]
    public class ActivityReg : Activity
    {
        EditText correo, usuario, contrasena;
        Button ok, cancelar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_reg);
            instancias();
            acciones();


            
        }

        private void acciones()
        {
            ok.Click += (sender, e) =>
            {
                registrarNUsuario(new Usuario());
                

            };

            cancelar.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);

            };
        }

        private void registrarNUsuario(Usuario usuario)
        {
            
        }

        private void instancias()
        {
            correo = FindViewById<EditText>(Resource.Id.correo);
            usuario = FindViewById<EditText>(Resource.Id.usuario);
            contrasena = FindViewById<EditText>(Resource.Id.contrasena);
            ok  = FindViewById<Button>(Resource.Id.okbut);
            cancelar = FindViewById<Button>(Resource.Id.cancelar);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}
