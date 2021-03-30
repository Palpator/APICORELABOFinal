using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Models
{
    public class Commentary
    {
        public string Content { get; set; }
        public int IdMovie { get; set; }
        public Guid IdUser { get; set; }
    }
}