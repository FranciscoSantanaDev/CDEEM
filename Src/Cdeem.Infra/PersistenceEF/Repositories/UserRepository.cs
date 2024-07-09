using Cdeem.Core.Entities;
using Cdeem.Core.Repositories;
using Cdeem.Infra.PersistenceEF.Context;
using Microsoft.EntityFrameworkCore;

namespace Cdeem.Infra.PersistenceEF.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private  DbSet<User> _users;

        public UserRepository(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
            _users = dbContext.Users;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(string Email, string password)
        {
            var query = _users.Include(c => c.Skills).AsQueryable();

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(password))
            {
                query = query.Where(c => c.Email == Email && c.Password==password);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            var entityState = _dbContext.Entry(user.Skills).State;
            _dbContext.Entry(user.Skills).State =
                entityState == EntityState.Detached
                    ? EntityState.Added
                    : entityState;

            await _dbContext.SaveChangesAsync();
        }
    }
}
