using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class UtilisateurUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Pseudo { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}