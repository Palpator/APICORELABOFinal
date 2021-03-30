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
    public class MoviesRepository : RepositoryBase<int, MoviesEntity>
    {
        public MoviesRepository() : base("Movies", "IdMovie")
        {}
        public override MoviesEntity Convert(IDataRecord reader)
        {
            return new MoviesEntity()
            {
                Id = (int)reader["IdMovie"],
                Title =reader["Title"].ToString(),
                YearRelease = (DateTime)reader["YearRelease"],
                Synopsis = reader["Synopsis"].ToString(),
                IdDirector=(int)reader["IdDirector"],
                IdWriter=(int)reader["IdWriter"]
            };
        }

        public EntityViewDetailFilm ConvertPerson(IDataRecord reader)
        {
            return new EntityViewDetailFilm()
            {
                RoleCasting = reader["RoleCasting"].ToString(),
                Acteur = reader["Acteur"].ToString(),
                IdPerson = (int)reader["IdPerson"]
            };
        }
        public EntityViewComFilm ConvertCom(IDataRecord reader)
        {
            return new EntityViewComFilm()
            {
                IdCom = (int)reader["IdCommentaries"],
                ContentCom = reader["Content"].ToString(),
                EtatMessage = (bool)reader["EtatMessage"],
                IdMovie = (int)reader["IdMovie"],
                IdUser = Guid.Parse(reader["IdUtilisateur"].ToString()),
                Pseudo = reader["Pseudo"].ToString(),
                IsAdmin = (bool)reader["IsAdmin"],
                EtatUser = (bool)reader["EtatUser"]
            };
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(MoviesEntity entity)
        {
            Command command = new Command("MoviesAdd", true);
            command.AddParameter("@Title", entity.Title);
            command.AddParameter("@YearRelease", entity.YearRelease);
            command.AddParameter("@Synopsis", entity.Synopsis);
            command.AddParameter("@IDDirector", entity.IdDirector);
            command.AddParameter("@IDWriter", entity.IdWriter);
            return (int)connection.ExecuteScalar(command);
        }

        public override bool Update(MoviesEntity data)
        {
            Command command = new Command("MoviesUpdate", true);
            command.AddParameter("@ID", data.Id);
            command.AddParameter("@Title", data.Title);
            command.AddParameter("@YearRelease", data.YearRelease);
            command.AddParameter("@Synopsis", data.Synopsis);
            command.AddParameter("@IDDirector", data.IdDirector);
            command.AddParameter("@IDWriter", data.IdWriter);
            return connection.ExecuteNonQuery(command)==1;
        }
        public IEnumerable<EntityViewDetailFilm> GetActorByFilmID(int id)
        {
            Command command = new Command("ViewDetailFilm", true);
            command.AddParameter("@IDFilm", id);
            return connection.ExecuteReader(command,ConvertPerson);
        }
        public IEnumerable<EntityViewComFilm> GetComByFilmId(int id)
        {
            Command command = new Command("ViewComByIdFilm", true);
            command.AddParameter("@ID", id);
            return connection.ExecuteReader(command,ConvertCom);
        }
    }
}
