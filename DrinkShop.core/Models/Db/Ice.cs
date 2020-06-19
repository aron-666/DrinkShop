using System;
using System.Collections.Generic;

namespace DrinkShop.core.Models.Db
{
    public partial class Ice : ITimeLogger
    {
        public Ice()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
