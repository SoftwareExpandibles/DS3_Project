using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class MonthlyOrderCounters
    {
        [Key]
        public DateTime MonthlyRecord { get; set; }
        public int OrdersInMonth { get; set; }
        public List<Item> ProductsPurchased { get; set; }
        public decimal MonthlySales { get; set; }
    }
}
