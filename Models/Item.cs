using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount()
        {
            return (decimal)(Product.Price * Quantity);
        }
        public virtual Order Order { get; set; }
    }
}