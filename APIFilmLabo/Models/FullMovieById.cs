using Api.Labo.DAL.Entities;
using APIFilmLabo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class FullMovieById
    {
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public DateTime YearRelease { get; set; }
        public string Synopsis { get; set; }
        public FullPerson Director { get; set; }
        public FullPerson Writer { get; set; }
        public IEnumerable<EntityViewDetailFilm> Actor { get; set; }
    }
}
