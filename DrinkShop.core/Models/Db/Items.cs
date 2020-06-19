using System;
using System.Collections.Generic;

namespace DrinkShop.core.Models.Db
{
    public partial class Items : ITimeLogger
    {
        public Items()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanIce { get; set; }
        public bool CanSize { get; set; }
        public bool CanSweetness { get; set; }
        public int BasePrice { get; set; }
        public int AddPrice { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
