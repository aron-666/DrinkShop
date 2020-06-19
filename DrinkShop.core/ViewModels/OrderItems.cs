using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.core.ViewModels
{
    public class OrderItems
    {
        public List<Items> Items { get; set; }

        public string Phone { get; set; }

        public string ClientID { get; set; }
    }
}
