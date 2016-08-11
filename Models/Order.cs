using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Username { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderTitle { get; set; }
        public List<Item> CartItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal AdditionalCost { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
        public Order()
        {
            CartItems = new List<Item>();
        }
    }
}
