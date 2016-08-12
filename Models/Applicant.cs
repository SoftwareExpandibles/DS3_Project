using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantID { get; set; }
        public string Username { get; set; }

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

        [Required(ErrorMessage = "Gender Field is Empty")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Email Address Field is Empty")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Address is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number Field is Empty")]
        [StringLength(10, ErrorMessage = "Invalid Contact Number", MinimumLength = 10)]
        [Display(Name = "Contact Number")]
        public string cell { get; set; }

        [Required(ErrorMessage = "Resident Address Field is Empty")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Province Field is Empty")]
        [Display(Name = "Province")]
        public string Province { get; set; } //Dropdown [9]

        [Required(ErrorMessage = "City Field is Empty")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal Code Field is Empty")]
        [Display(Name = "Zip/Postal Code")]
        [StringLength(4, ErrorMessage = "Invalid Postal Code")]
        public string zip { get; set; }

        [Required(ErrorMessage = "Institution Field is Empty")]
        [Display(Name = "Institution")]
        public string institution { get; set; }

        [Required(ErrorMessage = "Qualification Field is Empty")]
        [Display(Name = "Qualification")]
        public string qualification { get; set; }

        [Required(ErrorMessage = "Year Field is Empty")]
        [Display(Name = "Year of Qualification")]
        [DataType(DataType.Text)]
        public int year { get; set; }

        [Required]
        [Display(Name = "Motivation")]
        [DataType(DataType.MultilineText)]
        public string cv { get; set; }

        [Required(ErrorMessage = "Designation Field is Empty")]
        [Display(Name = "Designation")]
        public int jobID { get; set; }
        public virtual Job Jobs { get; set; }

        [Display(Name = "Reference Number")]
        public string AppRefNumber { get; set; }

        [Display(Name = "Application Date")]
        public System.DateTime ApplicationDate { get; set; }

        [Display(Name = "Date of Birth")]
        public string dob { get; set; }
    }
}
