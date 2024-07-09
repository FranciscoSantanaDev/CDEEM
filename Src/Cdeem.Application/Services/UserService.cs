using Cdeem.Application.InputModels;
using Cdeem.Application.ViewModel;
using Cdeem.Core.Entities;
using Cdeem.Core.Repositories;

namespace Cdeem.Application.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository useRepository)
        {
            _userRepository = useRepository;
        }

        public async Task Add(AddUserInputModel model)
        {
            var user = model.ToEntity();
            await _userRepository.AddAsync(user);
        }

        public async Task<UserViewModel> GetUser(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email, password);
            return UserViewModel.FromEntity(user);
        }

        public async Task Update(AddUserInputModel model)
        {
            var user = await _userRepository.GetUserAsync(model.Email, model.Password);
            user = new (model.Name, model.Email, model.Password, model.Skills.Select(s=>s.ToEntity()).ToList());
            await _userRepository.UpdateAsync(user);
        }
    }
}
