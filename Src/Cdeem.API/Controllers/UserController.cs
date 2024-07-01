using Cdeem.Application.InputModels;
using Cdeem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cdeem.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        [HttpPost]
        public async Task<IActionResult> Post(AddUserInputModel model)
        {
             await _userServices.Add(model);

            return Created();
        }
    }
}
