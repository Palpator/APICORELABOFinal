using Api.Labo.DAL.Entities;
using Api.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        protected Connection connection { get; }
        protected string TableName { get; }
        protected string IdName { get; }
        public RepositoryBase(string tableName , string idName ="Id")
        {
            connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBFilmLabo;Integrated Security=True;");
            TableName = tableName;
            IdName = idName;
        }
        public abstract TEntity Convert(IDataRecord reader);
        public virtual TEntity get(TKey id)
        {
            Command cmd = new Command("Select * from [" + TableName + "] WHERE "+IdName+" = @Id");
            cmd.AddParameter("@Id", id);
            return connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            Command cmd = new Command("Select * from [" + TableName + "]");
            return connection.ExecuteReader(cmd, Convert);
        }
        public abstract TKey Insert(TEntity entity);
        public abstract bool Update(TEntity data);
        public abstract bool Delete(TKey id);
    }
}
