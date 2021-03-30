using Api.Labo.DAL.Entities;
using Api.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Repositories
{
    public class CommentariesRepository : RepositoryBase<int, CommentariesEntity>
    {
        public CommentariesRepository():base("Commentaries", "IdCommentaries")
        {}
        public override CommentariesEntity Convert(IDataRecord reader)
        {
            return new CommentariesEntity()
            {
                Id = (int)reader["IdCommentaries"],
                Content = reader["Content"].ToString(),
                IsActive = (bool)reader["IsActive"],
                IdMovie = (int)reader["IdMovie"],
                IdUtilisateur =Guid.Parse(reader["IdUtilisateur"].ToString())
            };
        }

        public override bool Delete(int id)
        {
            Command command = new Command("CommentariesDelete", true);
            command.AddParameter("@id", id);
            return connection.ExecuteNonQuery(command) == 1;
        }

        public override int Insert(CommentariesEntity entity)
        {
            Command command = new Command("CommentariesAdd", true);
            command.AddParameter("@Content", entity.Content);
            command.AddParameter("@IdMovie", entity.IdMovie);
            command.AddParameter("@IdUser", entity.IdUtilisateur);
            return (int)connection.ExecuteScalar(command);
        }

        public override bool Update(CommentariesEntity data)
        {
            Command command = new Command("CommentariesUpdate", true);
            command.AddParameter("@Content", data.Content);
            command.AddParameter("@Id", data.Id);
            return connection.ExecuteNonQuery(command)==1;
        }
        public bool SwitchStateMessage(int Id)
        {
            Command command = new Command("CommentariesSwitchState", true);
            command.AddParameter("@ID", Id);
            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}
