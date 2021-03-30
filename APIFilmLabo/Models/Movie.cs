using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class Movie
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime YearRelease { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public int IdDirector { get; set; }
        [Required]
        public int IdWriter { get; set; }
        public IEnumerable<Casting>? ListCasting { get; set; }
    }
}
