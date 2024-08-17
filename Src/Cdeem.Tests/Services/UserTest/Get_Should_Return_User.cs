using AutoFixture;
using Cdeem.Application.Services;
using Cdeem.Application.ViewModel;
using Cdeem.Core.Entities;
using Cdeem.Core.Enum;
using Cdeem.Core.Repositories;
using Cdeem.Core.ValueObject;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Tests.Services.UserTest
{
    public class Get_Should_Return_User
    {
        private Mock<IUserRepository> _userRepository = new();
        private readonly Fixture _fixture = new();
        private readonly UserService _userService;
        private User user;
        private UserViewModel userVM;
        private string email;
        private string password;
        public Get_Should_Return_User()
        {
            _userService = new UserService(_userRepository.Object);
        }
        public async Task Execute()
        {
            Setup();
            var result = await _userService.GetUser(email, password);

            _userRepository.Verify(u => u.GetUserAsync(email, password), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userVM);
        }

        private void Setup()
        {
            var skills = new List<Skill>{
                            new Skill(
                                title: _fixture.Create<string>(),
                                description: _fixture.Create<string>(),
                                notes: new List<Note> { new Note(_fixture.Create<string>(),DateTime.Now) },
                                skillLevel: _fixture.Create<SkillLevel>(),
                                isPublic: _fixture.Create<bool>(),
                                user: new User(_fixture.Create<Guid>()))};

            email = _fixture.Create<string>();
            password = _fixture.Create<string>();
            user = new User(_fixture.Create<string>(), email, password, skills);
            userVM = UserViewModel.FromEntity(user);
            _userRepository.Setup(u => u.GetUserAsync(email, password)).ReturnsAsync(user);
        }
    }
}
