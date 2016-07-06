using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public string Username { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
