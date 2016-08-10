using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Models
{
    public class Genre
    {
        [Key]
        public int genreID { get; set; }

        [Required(ErrorMessage = "Catagory Field is Empty")]
        public string Catagory { get; set; }
        public ICollection<Product> Produt { get; set; }

    }
}
