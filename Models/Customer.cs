using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }

        [Required(ErrorMessage = "Username field can not be blank")]
        [Display(Name="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name Field can not be blank")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name field can not be blank")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address field can not be blank")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Address is not valid.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number can not be blank")]
        [StringLength(10, ErrorMessage = "Invalid Contact Number", MinimumLength = 10)]
        [Display(Name = "Contact Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Resident Address field can not be blank")]
        [Display(Name = "Resident Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Province field can not be blank")]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "City Field can not be blank")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal Code field can not be blank")]
        [Display(Name = "Postal Code")]
        [StringLength(4, ErrorMessage="Invalid Postal Code")]
        public string postalCode { get; set; }

    }
}
