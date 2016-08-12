using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class DailyReOrderCounters
    {
        [Key]
        public DateTime DatedReStock { get; set; }
        public int RestocksInADay { get; set; }
        public List<Item> ProductsPurchased { get; set; }
        public decimal TotalPaymentAmount { get; set; }
    }
}
