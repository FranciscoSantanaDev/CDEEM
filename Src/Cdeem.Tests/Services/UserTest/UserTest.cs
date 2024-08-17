using AutoFixture;
using Cdeem.Application.InputModels;
using Cdeem.Application.Services;
using Cdeem.Application.ViewModel;
using Cdeem.Core.Entities;
using Cdeem.Core.Enum;
using Cdeem.Core.Repositories;
using Cdeem.Core.ValueObject;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Moq;

namespace Cdeem.Tests.Services.UserTest
{
    public class UserTest
    {
        [Fact]
        public async Task Add_Should_Create_User()
        {
            await new Add_Should_Create_User().Execute();
        }

        [Fact]
        public async Task Get_Should_Return_User()
        {
            await new Get_Should_Return_User().Execute();
        }
    }
}
