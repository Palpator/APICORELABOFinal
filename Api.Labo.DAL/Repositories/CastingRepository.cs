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
    public class CastingRepository : RepositoryBase<int, CastingEntity>
    {
        public CastingRepository(): base("Casting")
        {}

        public override CastingEntity Convert(IDataRecord reader)
        {
            return new CastingEntity()
            {
                Id = (int)reader["Id"],
                RoleCasting = reader["RoleCasting"].ToString(),
                IdPerson = (int)reader["IdPerson"],
                IdMovie = (int)reader["IdMovie"]
            };
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(CastingEntity data)
        {
            Command command = new Command("CastingAdd", true);
            command.AddParameter("IdMovie", data.IdMovie);
            command.AddParameter("IdPerson", data.IdPerson);
            command.AddParameter("RoleCasting", data.RoleCasting);
            return (int)connection.ExecuteScalar(command);

        }

        public override bool Update(CastingEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
