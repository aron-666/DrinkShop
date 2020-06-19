using System;
using System.Collections.Generic;

namespace DrinkShop.core.Models.Db
{
    public partial class Orders : ITimeLogger
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Phone { get; set; }
        public string ClientId { get; set; }
        public int Price { get; set; }
        public bool Payment { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
