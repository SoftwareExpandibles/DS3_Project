using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }

        [Required]
        [Display(Name = "Delivery Type")]
        public string DeliveryType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 1000)]
        [Display(Name = "Delivery Charge: R")]
        public decimal DeliveryCharges { get; set; }
        

    }
}
