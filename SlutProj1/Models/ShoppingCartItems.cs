using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProj1.Models
{
    public class ShoppingCartItems
        
    {
        [Key]
        public int ShopingCartItemsID { get; set; }
        public Tshirt Tshirt { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }

    }
}
