using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Warehouse
    {
        [Key]
        public int warehouseID { get; set; }

        [Required(ErrorMessage = "Location Field is Empty")]
        [Display(Name = "Location")]
        public string location { get; set; }

        [Required(ErrorMessage = "Location Address Field is Empty")]
        [Display(Name = "Location Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number Field is Empty")]
        [Display(Name = "Contact Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address Field is Empty")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

    }
}
