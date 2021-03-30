using System.ComponentModel.DataAnnotations;

namespace APIFilmLabo.Controllers
{
    public class Person
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}