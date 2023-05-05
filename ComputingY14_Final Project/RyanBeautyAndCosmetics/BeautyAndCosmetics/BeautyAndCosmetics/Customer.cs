using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyAndCosmetics
{
    class Customer
    {

        private string _customerForename;
        private string _customerSurname;
        private string _customerEmail;
        private string _customerPhone;



        public Customer(string cf, string cs, string ce, string cp)
        {
            CustomerForename = cf;
            CustomerSurname = cs;
            CustomerEmail = ce;
            CustomerPhone = cp;

        }

        public string CustomerForename
        {
            get { return _customerForename; }
            set { if (ForenameCheck(value)) { _customerForename = value; } else { throw new Exception("Please Enter a Valid Customer Forename"); } }
        }

        public string CustomerSurname
        {
            get { return _customerSurname; }
            set { if (SurnameCheck(value)) { _customerSurname = value; } else { throw new Exception("Please Enter a Valid Customer Surname"); } }
        }

        public string CustomerEmail
        {
            get { return _customerEmail; }
            set { if (EmailCheck(value)) { _customerEmail = value; } else { throw new Exception("Please Enter a Valid Customer Email"); } }
        }

        public string CustomerPhone
        {
            get { return _customerPhone; }
            set { if (PhoneCheck(value)) { _customerPhone = value; } else { throw new Exception("Please Enter a Valid Customer Phone Number"); } }
        }



        public bool ForenameCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) ||  a.Length < 3 || a == "Customer Name")
            {
                return false;
            }
            else
            {
                if (!a.Any(Char.IsLetter))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }


        }


        public bool SurnameCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) && a.Length < 4 || a == "Customer Surname")
            {
                return false;
            }
            else
            {
                if (a.Any(Char.IsLetter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool PhoneCheck(string a )
        {
            if(a.Length != 11 || a == "Customer Phone")
            {
                return false;
            }
            else
            {
                if (a.Any(Char.IsNumber))
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }

        }


        public bool EmailCheck(string a)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(a);
                return addr.Address == a;
            }
            catch
            {
                return false;
            }

        }






    }
}
