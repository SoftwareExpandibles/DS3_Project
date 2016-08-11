using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class MonthlyOrderCounter
    {
        [Key]
        public DateTime MonthRecorded { get; set; }
        public int OrdersInAMonth { get; set; }
        public List<Item> ProductsPurchased { get; set; }
        public decimal MonthlySales { get; set; }
    }
}
