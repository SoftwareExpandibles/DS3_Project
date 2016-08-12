using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class DailyOrderCounters
    {
        [Key]
        public DateTime DatedRecord { get; set; }
        public int OrdersInADay { get; set; }
        public List<Item> ProductsPurchased { get; set; }
        public decimal DailySales { get; set; }
    }
}
