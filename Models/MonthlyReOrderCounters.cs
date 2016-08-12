using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class MonthlyReOrderCounters
    {
        [Key]
        public DateTime MonthlyRecord { get; set; }
        public int OrdersInMonth { get; set; }
        public List<Item> ProductsPurchased { get; set; }
        public decimal MonthlyPayments { get; set; }
    }
}
