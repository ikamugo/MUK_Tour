using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;

namespace EventsMicroservice.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: IEntity
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void Remove(string id);
        TEntity Update(TEntity entity);
    }
}
