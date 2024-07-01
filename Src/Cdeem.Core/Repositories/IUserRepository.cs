using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdeem.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync (User user);
        Task UpdateAsync (User user);
    }
}