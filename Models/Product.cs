using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string Title { get; set; }
        public string Photo { get; set; }
        public byte[] img { get; set; }
        [Required]
        [Range(0.01, 4000.00)]

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name = "Genre")]
        [ForeignKey("Genre")]
        public int genreId { get; set; }
        public virtual Genre Genre { get; set; }
        public string Color { get; set; }
        [Display(Name = "Size")]
        [ForeignKey("Size")]
        public int sizeId { get; set; }
        public virtual Size Size { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime Created { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}
