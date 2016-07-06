using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        public string Name { get; set; }
        public int DeliveryID { get; set; }
        public int OrderID { get; set; }
        public virtual Delivery Deliveries { get; set; }
        public virtual Order Orders { get; set; }
    }
}
