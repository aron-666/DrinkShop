using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.core.ViewModels
{
    public class ResponseCreateOrder
    {
        public string PayUrl { get; set; }
        public string OrderUrl { get; set; }
        public int Price { get; set; }

    }
}
