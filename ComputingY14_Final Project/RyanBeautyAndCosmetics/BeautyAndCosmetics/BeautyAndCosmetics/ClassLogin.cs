using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyAndCosmetics
{
    class ClassLogin
    {
        private string _username;
        private string _password;

        public static string Splash;
        public static string TableS;


        public ClassLogin(string u, string p)
        {

            Username = u;
            Password = p;
        }

        public string Username
        {
            get { return _username; }
            set { if (UsernameNull(value)){ _username = value; } else { throw new Exception("Please Enter a Valid Username"); } } 
        }

        public string Password
        {
            get { return _password; }
            set { if (PasswordCheck(value) && PasswordSymbol(value))  { _password = value; } else { throw new Exception("Please Enter a Valid Password"); } }
        }


        public bool UsernameNull(string a)
        {
            if (!string.IsNullOrWhiteSpace(a) && a.Length >4)
            {
                return true;
            }
            else
            {

                return false;
            }

        }

        public bool PasswordCheck(string a)
        {
            if (!string.IsNullOrWhiteSpace(a) && a.Length > 4)
            {
                return true;

            }
           
            else
            {

                return false;
            }

        }


        public bool PasswordSymbol(string a)
        {
            if(a.Any(char.IsPunctuation) || a.Any(char.IsDigit))
            {
                return true;

            }

            else
            {

                return false;
            }

        }

    }
}
