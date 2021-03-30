using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Entities
{
    public class CommentariesEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int IdMovie { get; set; }
        public Guid IdUtilisateur { get; set; }
    }
}
