using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Job
    {
        [Key]
        public int jobID { get; set; }

        [Required(ErrorMessage = "Provide job Code")]
        [Display(Name = "Job Code")]
        public string jobCode { get; set; }

        [Required(ErrorMessage = "Provide job title!")]
        [Display(Name = "Job Title")]
        public string jobTitle { get; set; }

        [Required(ErrorMessage = "Provide job description!")]
        [Display(Name = "Job Description")]
        [DataType(DataType.MultilineText)]
        public string jobDescription { get; set; }

        [Required(ErrorMessage = "Provide job requirements!")]
        [Display(Name = "Job Requirements")]
        [DataType((DataType.MultilineText))]
        public string jobRequirements { get; set; }

        [Required(ErrorMessage = "Proving the type of job!")]
        [Display(Name = "Job Type")]
        public string jobType { get; set; }

        [Required(ErrorMessage = "Privide closing date!")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Closing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime closingDate { get; set; }
        public List<Applicant> Applicants { get; set; }
    }
}
