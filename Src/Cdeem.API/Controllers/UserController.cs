using Cdeem.Application.InputModels;
using Cdeem.Application.Services;
using Cdeem.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cdeem.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(AddUserInputModel model)
        {
             await _userServices.Add(model);

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(AddUserInputModel model)
        {
            await _userServices.Update(model);

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string email, string password)
        {
            return Ok(await _userServices.GetUser(email, password));
        }
    }
}
