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
        public System.DateTime OrderDate { get; set; }

        [Display(Name="Delivery")]
        public int DeliveryID { get; set; }
        public decimal Total { get; set; }

        [Display(Name ="Transaction")]
        public int TransactionID { get; set; }

        [Display(Name = "Order Status")]
        public int OrderStatusID { get; set; }
        public virtual OrderStatus OrderStatuses { get; set; }
        public virtual Transaction Transactions { get; set; }
        public virtual Delivery Deliveries { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        

    }
}
