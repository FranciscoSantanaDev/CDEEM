using Cdeem.Application.InputModels;
using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.ViewModel
{
    public record UserViewModel(string name, string email, IEnumerable<SkillViewModel> skills)
    {
        public static UserViewModel FromEntity(User user) => new UserViewModel(user.Name, user.Email, user.Skills.Select(SkillViewModel.FromEntity));
    };
}
