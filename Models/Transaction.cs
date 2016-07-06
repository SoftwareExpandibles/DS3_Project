using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public virtual Order Orders { get; set; }

    }
}
