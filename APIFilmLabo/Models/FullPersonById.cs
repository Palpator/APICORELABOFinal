using Api.Labo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class FullPersonById
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<EntityViewListFilmByPerson> ListFilmsActor { get; set; }
        public IEnumerable<EntityViewListFilmByPerson> ListFilmsDirector { get; set; }
        public IEnumerable<EntityViewListFilmByPerson> ListFilmsWriter { get; set; }
    }
}
