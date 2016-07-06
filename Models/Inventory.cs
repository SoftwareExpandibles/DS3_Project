using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get;set;}

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int StockOnHand { get; set; }
        public int ReOrderQuantity { get; set; }
    }
}
