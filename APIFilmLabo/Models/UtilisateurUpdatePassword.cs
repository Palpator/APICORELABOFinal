using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class UtilisateurUpdatePassword
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}