using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.ViewModel
{
    public record UserViewModel(string name, string email, List<Skill> skills);
}
