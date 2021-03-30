using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class UtilisateurSwitch
    {
        [Required]
        public Guid Id { get; set; }
    }
}
