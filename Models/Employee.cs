using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models;
using System.Data.Entity;

namespace Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }

        [Required(ErrorMessage = "Title Field is Empty")]
        [Display(Name = "Title")]
        public string Title { get; set; } //Dropdown [Mr, Mrs, Miss, Dr, Prof]

        [Required(ErrorMessage = "First Name Field is Empty")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Field is Empty")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Identity Number Field is Empty")]
        [StringLength(13, ErrorMessage = "Invalid Identity Number", MinimumLength = 13)]
        [Display(Name = "Identity Number")]
        public string IdNo { get; set; }

        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }
       
        [Required(ErrorMessage = "Hire date Field is Empty")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime hireDate { get; set; }

        [Required(ErrorMessage = "Role Field is Empty")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Employee Number")]
        public string empno { get; set; }

        [Required(ErrorMessage = "Salary Filed is Empty")]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary: R")]
        [Range(1000, 100000, ErrorMessage = "Salary Range must be R1000 - R100 000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Email Address Field is Empty")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Address is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number Field is Empty")]
        [StringLength(10, ErrorMessage = "Invalid Contact Number", MinimumLength = 10)]
        [Display(Name = "Contact Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Resident Address Field is Empty")]
        [Display(Name = "Resident Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Province Field is Empty")]
        [Display(Name = "Province")]
        public string Province { get; set; } //Dropdown [9]

        [Required(ErrorMessage = "City Field is Empty")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal Code Field is Empty")]
        [Display(Name = "Postal Code")]
        [StringLength(4, ErrorMessage = "Invalid Postal Code")]
        public string postalCode { get; set; }


    }
}
