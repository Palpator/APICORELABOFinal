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
    public class UtilisateurRepository : RepositoryBase<Guid, UtilisateurEntity>
    {
        public UtilisateurRepository() : base("Utilisateur", "IdUtilisateur") { }

        public override UtilisateurEntity Convert(IDataRecord reader)
        {
            return new UtilisateurEntity()
            {
                Id = Guid.Parse(reader["IdUtilisateur"].ToString()),
                Email = reader["Email"].ToString(),
                Pseudo = reader["Pseudo"].ToString(),
                Birthdate = (DateTime)reader["Birthdate"],
                Password = null,
                IsAdmin = (bool)reader["IsAdmin"],
                IsActive = (bool)reader["IsActive"]
            };
        }
        public override bool Delete(Guid id)
        {
            Command command = new Command("UserDelete", true);
            command.AddParameter("@ID", id);
            return connection.ExecuteNonQuery(command)==1;
        }
        public override Guid Insert(UtilisateurEntity entity)
        {
            Command command = new Command("UserAdd", true);
            command.AddParameter("@Email", entity.Email);
            command.AddParameter("@Pseudo", entity.Pseudo);
            command.AddParameter("@Birthdate", entity.Birthdate);
            command.AddParameter("@Password", entity.Password);
            return (Guid)connection.ExecuteScalar(command);
        }
        public override bool Update(UtilisateurEntity data)
        {
            Command command = new Command("UserUpdate", true);
            command.AddParameter("@Id", data.Id);
            command.AddParameter("@Pseudo", data.Pseudo);
            command.AddParameter("@Birthdate", data.Birthdate);
            return connection.ExecuteNonQuery(command) == 1;
        }
        public bool ChangePassword(UtilisateurEntity data)
        {
            Command command = new Command("UserUpdatePassword", true);
            command.AddParameter("@Id", data.Id);
            command.AddParameter("@Password", data.Password);
            return connection.ExecuteNonQuery(command) == 1;
        }
        public UtilisateurEntity Login(string email,string password)
        {
            Command command = new Command("UserLogin", true);
            command.AddParameter("@Email", email);
            command.AddParameter("@Password", password);
            return connection.ExecuteReader(command, Convert).SingleOrDefault();
        }
        public bool SwitchAdmin(Guid Id)
        {
            Command command = new Command("UserSwitchAdmin", true);
            command.AddParameter("@ID", Id);
            return connection.ExecuteNonQuery(command) == 1;
        }
        public bool SwitchBan(Guid Id)
        {
            Command command = new Command("UserSwitchBan", true);
            command.AddParameter("@ID", Id);
            return connection.ExecuteNonQuery(command) == 1;
        }
    }
}