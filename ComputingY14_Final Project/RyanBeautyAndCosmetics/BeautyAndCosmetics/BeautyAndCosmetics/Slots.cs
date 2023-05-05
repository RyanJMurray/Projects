using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyAndCosmetics
{
    class Slots
    {
        private string _SlotTime;


        public Slots(string s)
        {


        }

        public string SlotTime
        {
            get { return _SlotTime; }
            set { if (SlotTimeCheck(value)) { _SlotTime = value; } else { throw new Exception("Please Enter a Valid Slot Time"); } }
        }

      

        public bool SlotTimeCheck(string a)
        {
            if (a.Length > 13)
            {
                return false;
            }
            else if (a.Any(Char.IsLetter))
                {
                return false;
                }
            else
            {
                if (string.IsNullOrEmpty(a))
                {
                    return false;
                }
            }
            return true;



        }

    }
}
