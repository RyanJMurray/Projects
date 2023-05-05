using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyAndCosmetics
{
    class BookingSimpsons
    {

        private string _staff;
        private string _slot;
        private string _room;
        private string _treatment;
        private string _paid;
        private string _bookingCode;


        public BookingSimpsons(string bc, string sl, string r, string t, string st, string p)

        { 
            BookingCode = bc;
            Slot = sl;
            Room = r;
            Treatment = t;
            Staff = st;                 
            Paid = p;
          
        }


        public string Slot
        {
            get { return _slot; }
            set { if (SlotCheck(value)) { _slot = value; } else { throw new Exception("Please Select a Time Slot"); } }
        }

        public string Room
        {
            get { return _room; }
            set { if (RoomCheck(value)) { _room = value; } else { throw new Exception("Please Select a Room"); } }
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

        public string BookingCode
        {
            get { return _bookingCode; }
            set { if (BookingCodeCheck(value)) { _bookingCode = value; } else { throw new Exception("Please Select a Booking From the Table"); } }
        }

        public bool SlotCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "Time Slots")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool RoomCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "Rooms")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool BookingCodeCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) || a == "Booking Code")
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
            if (string.IsNullOrWhiteSpace(a) || a == "Staff Member")
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
            if (string.IsNullOrWhiteSpace(a) || a == "Treatments")
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
    }
}
