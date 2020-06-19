using System;
using System.Collections.Generic;

namespace DrinkShop.core.Models.Db
{
    public partial class OrderItems : ITimeLogger
    {
        public long Id { get; set; }
        public int IdOrder { get; set; }
        public int IdItem { get; set; }
        public int Count { get; set; }
        public int IdIce { get; set; }
        public int IdSize { get; set; }
        public int IdSweetness { get; set; }
        public int Price { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Remarks { get; set; }

        public virtual Ice IdIceNavigation { get; set; }
        public virtual Items IdItemNavigation { get; set; }
        public virtual Orders IdOrderNavigation { get; set; }
        public virtual Size IdSizeNavigation { get; set; }
        public virtual Sweetness IdSweetnessNavigation { get; set; }
    }
}
