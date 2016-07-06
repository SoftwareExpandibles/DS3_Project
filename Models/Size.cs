using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Models
{
   public  class Size
    {
        [Key]
        public int sizeId { get; set; }
        public string ActualSize { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
