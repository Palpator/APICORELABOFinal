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
    public class PersonRepository : RepositoryBase<int, PersonEntity>
    {
        public PersonRepository() : base("Person","IdPerson")
        {}
        public override PersonEntity Convert(IDataRecord reader)
        {
            return new PersonEntity()
            {
                Id = (int)reader["IdPerson"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString()
            };
        }
        public EntityViewListFilmByPerson ConvertPerson(IDataRecord reader)
        {
            return new EntityViewListFilmByPerson()
            {
                Title = reader["Title"].ToString(),
                IdMovie = (int)reader["IdMovie"]
            };
        }
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public override int Insert(PersonEntity data)
        {
            Command command = new Command("PersonAdd", true);
            command.AddParameter("@LastName", data.LastName);
            command.AddParameter("@FirstName", data.FirstName);
            return (int)connection.ExecuteScalar(command);
        }
        public override bool Update(PersonEntity data)
        {
            Command command = new Command("PersonUpdate", true);
            command.AddParameter("@Id", data.Id);
            command.AddParameter("@LastName", data.LastName);
            command.AddParameter("@FirstName", data.FirstName);
            return connection.ExecuteNonQuery(command)==1;
        }

        public IEnumerable<EntityViewListFilmByPerson> GetFilmsByIDActors(int id)
        {
            Command command = new Command("ViewPersonFilmList", true);
            command.AddParameter("@IdActeur", id);
            return connection.ExecuteReader(command, ConvertPerson);
        }
        public IEnumerable<EntityViewListFilmByPerson> GetFilmsByIDDirector(int id)
        {
            Command command = new Command("ViewPersonDirectorFilmList", true);
            command.AddParameter("@id", id);
            return connection.ExecuteReader(command, ConvertPerson);
        }
        public IEnumerable<EntityViewListFilmByPerson> GetFilmsByIDWriter(int id)
        {
            Command command = new Command("ViewPersonWriterFilmList", true);
            command.AddParameter("@id", id);
            return connection.ExecuteReader(command, ConvertPerson);
        }
    }
}