using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Entities
{
    public class EntityViewComFilm
    {
        public int IdCom { get; set; }
        public string ContentCom { get; set; }
        public bool EtatMessage { get; set; }
        public int IdMovie { get; set; }
        public Guid IdUser { get; set; }
        public string Pseudo { get; set; }
        public bool IsAdmin { get; set; }
        public bool EtatUser { get; set; }
    }
}
