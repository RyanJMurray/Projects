using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyAndCosmetics
{
    class Product
    {

        private string _ProductName;
        private string _ProductPrice;


        public Product(string pn, string pp)
        {
            ProductName = pn;
            ProductPrice = pp;

        }


        public string ProductName
        {
            get { return _ProductName; }
            set { if (ProductNameCheck(value)) { _ProductName = value; } else { throw new Exception("Please Enter a Valid Product Name"); } }
        }

        public string ProductPrice
        {
            get { return _ProductPrice; }
            set { if (ProductPriceCheck(value)) { _ProductPrice= value; } else { throw new Exception("Please Enter a Valid Product Price"); } }
        }

        public bool ProductNameCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) && a.Length < 3 || a == "Product Name")
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

        public bool ProductPriceCheck(string a)
        {
            if (string.IsNullOrWhiteSpace(a) && a.Length < 1 || a == "Product Price")
            {
                return false;
            }
            else
            {
                if (a.Any(Char.IsDigit) && a.Length > 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
