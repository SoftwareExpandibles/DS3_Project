using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Models
{
    public class EventOrder
    {
        [Key]
        public int orderID { get; set; }
        [Required]
        [Display(Name = "Event Type")]
        public string eventType { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Replied")]
        public bool replied { get; set; }
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        public DateTime deadline { get; set; }
        public string manipulate { get; set; }
        public virtual ICollection<OrderImage> OrderImage { get; set; }
    }
    public class OrderImage
    {
        [Key]
        public int imageID { get; set; }
        public string email { get; set; }
        public byte[] image { get; set; }

        public virtual Order Orders { get; set; }
    }

    public class OrderImageViewModel
    {
        [Required]
        [Display(Name = "Event Type")]
        public string eventType { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        public DateTime deadline { get; set; }
        public List<HttpPostedFileBase> image { get; set; }
    }
}

