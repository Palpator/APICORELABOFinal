using Api.Labo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Labo.DAL.Repositories
{
    public interface IRepository<TKey,TEntity> where TEntity : IEntity<TKey>
    {
        TKey Insert(TEntity entity);
        TEntity get(TKey id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity data);
        bool Delete(TKey id);
    }
}
