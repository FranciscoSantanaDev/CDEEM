using Cdeem.Core.Entities;
using Cdeem.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.Persistence.Repositories
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        public UserMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("Users");
        }
        public async Task AddAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<User>.Update.Set(u => u, user);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.Email, email),
                Builders<User>.Filter.Eq(u => u.Password, password)
                );

            return await _collection.Find(filter).FirstAsync();
        }
    }
}
