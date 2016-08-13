using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmailReply
    {
        [Key]
        public int replyID { get; set; }
        public string emailTo { get; set; }
        public int orderId { get; set; }
        public double Amount { get; set; }
        public string text { get; set; }
    }
}
