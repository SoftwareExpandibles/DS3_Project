using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStutasID { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public bool New { get; set; }
        public bool Hold { get; set; }
        public bool Delivered { get; set; }
        public bool Paid { get; set; }
        public bool Closed { get; set; }
        public List<Order> Orders { get; set; }
    }
}
