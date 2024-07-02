using Cdeem.Application.InputModels;
using Cdeem.Application.ViewModel;
using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.Services
{
    public interface IUserServices
    {
        Task Add(AddUserInputModel addUserInputModel);
        Task Update(AddUserInputModel addUserInputModel);

        Task<UserViewModel> GetUser(string Email, string password);
    }
}
