using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rangamo.Models
{
    public class Rating
    {
        [Key]
        public int id { get; set; }
        public string rate { get; set; }
    }
}