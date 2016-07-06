using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SpecialOrder
    {
        [Key]
        public int SpecialOrderID { get; set; }
        public string Username { get; set; }
        public byte[] Image { get; set; }

        [Required(ErrorMessage="Order Description Field is Empty")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        
        
    }
}
