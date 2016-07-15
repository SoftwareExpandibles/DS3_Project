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
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}