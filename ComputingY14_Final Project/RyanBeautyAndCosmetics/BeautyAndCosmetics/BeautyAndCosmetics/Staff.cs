using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BeautyAndCosmetics
{
    class Staff
    {
       // private int _StaffNumber; //dont know if need, if not change constructor
        private string _staffForename;
        private string _staffSurname;
        private string _staffContract;

        public Staff(string sf, string ss, string sc)
        {
            StaffForename = sf;
            StaffSurname = ss;
            StaffContract = sc;
        }

        public string StaffForename
        {
            get { return _staffForename; }
            set { if (ForenameCheck(value)) { _staffForename = value; } else { throw new Exception("Please Enter a Valid Staff Forename"); } }
        }

        public string StaffSurname
        {
            get { return _staffSurname; }
            set { if (SurnameCheck(value)) { _staffSurname = value; } else { throw new Exception("Please Enter a Valid Staff Surname"); } }
        }

        public string StaffContract
        {
            get { return StaffContract; }
            set { if (ContractCheck(value)) { _staffContract = value; } else { throw new Exception("Please Enter a Valid Staff Contract"); } }
        }

        public bool ForenameCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "Staff Name")
            {
                return false;
            }
            else
            {
                if (a.Any(Char.IsLetter) && a.Length > 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SurnameCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a)  || a == "Staff Surname")
            {
                return false;
            }
            else
            {
                if (a.Any(Char.IsLetter) && a.Length > 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContractCheck(string a)
        {
           
          if(string.IsNullOrEmpty(a) || a == "Staff Contract")
            {
                return false;
            }
            else
            {
                if (a == "PART TIME" || a == "FULL TIME" || a == "part time" || a == "full time" )
                {
                    return true;
                }
            }
            return false;
        }


    }

}
