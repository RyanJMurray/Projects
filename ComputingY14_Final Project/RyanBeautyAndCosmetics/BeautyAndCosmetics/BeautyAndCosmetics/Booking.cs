using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BeautyAndCosmetics
{
    class Booking
    {

        private string _staff;
        private string _treatment;
        private string _paid;
        private string _customer;



        public Booking(string st, string c, string t, string p)

        {
            Staff = st;
            Customer = c;
            Treatment = t;
            Paid = p;
        }

      

        public string Staff
        {
            get { return _staff; }
            set { if (StaffCheck(value)) { _staff = value; } else { throw new Exception("Please Select a Staff Member"); } }
        }

      

        public string Treatment
        {
            get { return _treatment; }
            set { if (TreatmentCheck(value)) { _treatment = value; } else { throw new Exception("Please Select a Treatment"); } }
        }


        public string Paid
        {
            get { return _paid; }
            set { if (PaidCheck(value)) { _paid = value; } else { throw new Exception("Please Select If You Are Paying Now or Later"); } }
        }

        public string Customer
        {
            get { return _customer; }
            set { if (CustomerCheck(value)) { _customer = value; } else { throw new Exception("Please Select a Customer"); } }
        }

        public bool CustomerCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "Customer")
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public bool StaffCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) ||  a == "Staff")
            {
                return false;
            }
            else
            {            
                    return true;               
            }
        }

    

        public bool TreatmentCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "Treatment")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool PaidCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "null")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static Dictionary<int, string> getSlots()
        {
            Dictionary<int, string> slots = new Dictionary<int, string>();
            slots.Add(1, "Slot Time: 9:00AM - 10:00AM");
            slots.Add(2, "Slot Time: 9:30AM - 10:30AM");
            slots.Add(3, "Slot Time: 10:00AM - 11:00AM");
            slots.Add(4, "Slot Time: 10:30AM - 11:30AM");
            slots.Add(5, "Slot Time: 11:00AM - 12:00PM");
            slots.Add(6, "Slot Time: 12:30PM - 13:30PM");
            slots.Add(7, "Slot Time: 13:00PM - 14:00PM");
            slots.Add(8, "Slot Time: 13:30PM - 14:30PM");
            slots.Add(9, "Slot Time: 14:00PM - 15:00PM");
            slots.Add(10, "Slot Time: 14:30PM - 15:30PM");
            slots.Add(11, "Slot Time: 15:00PM - 16:00PM");
            slots.Add(12, "Slot Time: 15:30PM - 16:30PM");
            slots.Add(13, "Slot Time: 16:00PM - 17:00PM");
            slots.Add(14, "Slot Time: 16:30PM - 17:30PM");
            slots.Add(15, "Slot Time: 17:00PM - 18:00PM");
            slots.Add(16, "Slot Time: 17:30PM - 18:30PM");
            slots.Add(17, "Slot Time: 18:00PM - 19:00PM");
            slots.Add(18, "Slot Time: 18:30PM - 19:30PM");
            slots.Add(19, "Slot Time: 19:00PM - 20:00PM");
            slots.Add(20, "Slot Time: 19:30PM - 20:30PM");
            slots.Add(21, "Slot Time: 20:00PM - 21:00PM");
         
            return slots;


        }


    }
}
