using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Entities
{
    public class UtilisateurEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

    }
}
