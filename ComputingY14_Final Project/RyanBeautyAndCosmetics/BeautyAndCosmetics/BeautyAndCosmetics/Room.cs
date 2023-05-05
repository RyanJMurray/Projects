using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyAndCosmetics
{
    class Room
    {

        private string _description;

        public Room(string d)
        {
            Description = d;
        }


        public string Description
        {
            get { return _description; }
            set { if (DescriptionCheck(value)) { _description = value; } else { throw new Exception("Please Enter a Valid Room Description"); } }
        }

    





        public bool DescriptionCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) && a.Length < 4 || a == "Room Description")
            {
                return false;
            }
            else
            {
                if (a.Any(Char.IsLetter)  && a.Length >4)
                {
                    return true;
                }
            }
            return false;
        }

        
        public static Dictionary<int, string> getRoom()
        {
            Dictionary<int, string> room = new Dictionary<int, string>();
            room.Add(1, "Treatment Room 1 ");
            room.Add(2, "Treatment Room 2");
            room.Add(3, "Treatment Room 3");
            room.Add(4, "Nail Bar");
          

            return room;


        }
    }
}
