using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Entities
{
    public class MoviesEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime YearRelease { get; set; }
        public string Synopsis { get; set; }
        public int IdDirector { get; set; }
        public int IdWriter { get; set; }
    }
}
