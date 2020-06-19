using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.core.ViewModels
{
    public class ResponseItem : Items
    {
        public int Price { get; set; }
    }

    public class ResponseItems
    {
        public int Total => Items.Sum(x => x.Price);
        public List<ResponseItem> Items { get; set; }
    }
}
