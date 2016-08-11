using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rangamo.Models
{
    public class messages
    {
        [Key]
        public int messageID { get; set; }
        public string userName { get; set; }
        public string message { get; set; }
        public string Email { get; set; }
        public DateTime Message_date { get; set; }
    }
}