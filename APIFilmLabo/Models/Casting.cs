using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class Casting
    {
        [Required]
        public int IdMovie { get; set; }
        [Required]
        public int IdPerson { get; set; }
        [Required]
        public string RoleCasting { get; set; }
    }
}