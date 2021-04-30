using System;
using Android.OS;

namespace Proyectos1
{
    
    public class Usuario
    {
        private string email;
        private string pass;
        private int id;
        private string user_name;

        public Usuario(string email, string pass, int id)
        {
            this.id = id;
            this.email = email;
            this.pass = pass;
            
        }
        public Usuario(string email, string pass, int id, string user)
        {
            this.id = id;
            this.email = email;
            this.pass = pass;
            this.user_name = user;

        }


        public Usuario(string email, string pass)
        {
            this.email = email;
            this.pass = pass;

        }


        public Usuario()
        {

        }

        public void setUserNAme(string user)
        {
            this.user_name = user;
        }
        public string getUser()
        {
            return this.user_name;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }
        public void setPass(string pass)
        {
            this.pass = pass;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getPass()
        {
            return this.pass;
        }

        public static explicit operator Parcelable(Usuario v)
        {
            throw new NotImplementedException();
        }
    }
}
