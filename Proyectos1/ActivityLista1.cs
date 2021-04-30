
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Proyectos1.Resources
{
    [Activity(Label = "ActivityLista1")]
    public class ActivityLista1 : Activity
    {
        Usuario u;
        string opc;
        RecyclerView lista;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            u = (Usuario)savedInstanceState.GetSerializable("usuario");
            opc = savedInstanceState.GetString("OPCION");
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_listauno);
            // Create your application here
        }
    }
}
