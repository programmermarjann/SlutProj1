using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProj1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }

    }
    
}
