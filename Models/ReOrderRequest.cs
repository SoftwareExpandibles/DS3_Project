using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class ReOrderRequest
    {
        [Key]
        public int ReOrderId { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReOrderDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime ReOrderTime { get; set; }
        public string Status { get; set; }
        public bool Approval { get; set; }
    }
}
