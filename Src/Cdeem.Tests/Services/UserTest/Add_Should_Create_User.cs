using AutoFixture;
using Cdeem.Application.InputModels;
using Cdeem.Application.Services;
using Cdeem.Core.Entities;
using Cdeem.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Tests.Services.UserTest
{
    public class Add_Should_Create_User
    {
        public Mock<IUserRepository> _userRepository = new();
        public readonly Fixture _fixture = new(); 
        public readonly UserService _userService;

        public Add_Should_Create_User()
        {
            _userService = new UserService(_userRepository.Object);
        }
        public async Task Execute()
        {
            var UserVM = _fixture.Create<AddUserInputModel>();
            _userRepository.Setup(u => u.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            await _userService.Add(UserVM);

            _userRepository.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
