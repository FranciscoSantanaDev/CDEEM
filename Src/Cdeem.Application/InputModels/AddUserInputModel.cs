using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.InputModels
{
    public record AddUserInputModel(string Name, string Email, string Password, IEnumerable<AddSkillInputModel> Skills)
    {
        public User ToEntity()
            => new User(Name, Email, Password, Skills.Select(s => s.ToEntity()).ToList());
    };


}
