using Cdeem.Application.InputModels;
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

        public async Task Update(AddUserInputModel model)
        {
            var user = model.ToEntity();
            await _userRepository.UpdateAsync(user);
        }
    }
}
