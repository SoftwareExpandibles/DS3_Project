using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Contact Number Field is Empty")]
        [StringLength(10, ErrorMessage = "Invalid Contact Number", MinimumLength = 10)]
        [Display(Name = "Contact Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address Field is Empty")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Address is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Supplier Address Field is Empty")]
        [Display(Name = "Supplier Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Location Field is Empty")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Postal Code Field is Empty")]
        [Display(Name = "Postal Code")]
        [StringLength(4, ErrorMessage = "Invalid Postal Code")]
        public string postalCode { get; set; }


        
    }
}
