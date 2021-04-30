using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Data;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;
using System.Collections.Generic;
using Java.Lang;

namespace Proyectos1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText user, pass;
        Usuario usuario_actual = new Usuario();
        Button login, registro;
        TextView er;

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
            er = FindViewById<TextView>(Resource.Id.er);
            //se dan las acciones que van a utilizar cada uno de ellos
            acciones();

        }

        private void acciones()
        {
            //al pulsar el boton de login recoger los datos de los campos que permiten  hacer una consulta a la bbdd
            //para comprobar que estan registrados
            login.Click += (sender, e) =>
             {
                 /*
                 if(Comprobar(new Usuario("example","example")))
                 {
                     Toast.MakeText(this, "", ToastLength.Long).Show();
                     Intent intent = new Intent(this, typeof(HomeActivity));
                     StartActivity(intent)
                     ;

                 }
                 else
                 {
                     
                     
                 }*/

                 if(TryConnection(this, user.Text, pass.Text))
                 {
                     Toast.MakeText(this, "Eres un dios", ToastLength.Long).Show();
                     Thread.Sleep(200);
                     Toast.MakeText(this, "", ToastLength.Long).Show();
                     Intent intent = new Intent(this, typeof(HomeActivity));
                     StartActivity(intent);

                 }
                 else
                 {
                     Toast.MakeText(this, "Eres un mierdas", ToastLength.Long).Show();
                     AlertDialog.Builder alert = new AlertDialog.Builder(this);
                     alert.SetTitle("Alerta");
                     alert.SetMessage("No estas registrado, por favor registrate en la pagina a la que seras redirigido");
                     alert.SetPositiveButton("ok", OkAction);
                     var dialogo = alert.Create();
                     dialogo.Show();

                 }
                 

             };
            registro.Click += (sender, e) =>
            {
                Intent intent = new Intent(this,typeof(ActivityReg));
                StartActivity(intent);

            };
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            var myButton = sender as Button; //this will give you the OK button on the dialog but you're already in here so you don't really need it - just perform the action you want to do directly unless I'm missing something..
            if (myButton != null)
            {
                Intent intent = new Intent(this, typeof(ActivityReg));
                StartActivity(intent);

            }
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool TryConnection(Context context, string user, string contrasena)
        {
           
            MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
            Builder.Port = 3306;
    
            Builder.Server = "192.168.1.54";
            Builder.Database = "proyectos";
            Builder.UserID = "root"; //Es el usuario de la base de datos
            Builder.Password = "root"; //La contraseña del usuario
            try
            {
                MySqlConnection ms = new MySqlConnection(Builder.ToString());
                ms.Open();

                using var command = ms.CreateCommand();
                command.CommandText = "select * from usuario ";
                
                using var lector = command.ExecuteReader();

                if (lector.Read().ToString() != null)
                {
                    while (lector.Read())
                    {
                        Usuario temp = new Usuario();
                        temp.setId(lector.GetInt32("id"));
                        temp.setUserNAme(lector.GetString("nombre"));
                        temp.setEmail(lector.GetString("correo"));
                        temp.setPass(lector.GetString("contrasena"));
                        usuario_actual = temp;
                        Console.WriteLine(temp.getUser());

                    }


                    return true;

                }
                else
                {
                    return false;
                }

                


            }
            catch (Java.Lang.Exception ex)
            {
                Console.WriteLine(ex.ToString());

                Toast.MakeText(context, ex.ToString(), ToastLength.Long).Show();
                //Muestra un Toast con el error (Puede ser muy largo)
                er.Text = ex.ToString();
                return false;
            }
        }
    }
          


            
        
    

}
