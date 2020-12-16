using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EventsMicroservice.Data.Models;
using EventsMicroservice.Data.Repositories.Interfaces;
using EventsMicroservice.Data.Settings;
using MongoDB.Driver;

namespace EventsMicroservice.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: IEntity
    {
        private readonly IMongoCollection<TEntity> _repository;

        public GenericRepository(IDatabaseSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _repository = database.GetCollection<TEntity>(collectionName);
        }

        public TEntity Add(TEntity entity)
        {
            _repository.InsertOne(entity);
            return entity;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate).ToEnumerable();
        }

        public TEntity Get(string id)
        {
            return _repository.Find(t => t.Id == id).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.Find(t => true).ToEnumerable();
        }

        public void Remove(TEntity entity)
        {
            _repository.DeleteOne(t => t.Id == entity.Id);
        }

        public void Remove(string id)
        {
            _repository.DeleteOne(t => t.Id == id);
        }

        public TEntity Update(TEntity entity)
        {
            _repository.ReplaceOne(t => t.Id == entity.Id, entity);
            return entity;
        }
    }
}
