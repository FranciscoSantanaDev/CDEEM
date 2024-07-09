using Cdeem.Application.InputModels;
using Cdeem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cdeem.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillController : Controller
    {
        private readonly ISkillServices _skillServices;

        public SkillController(ISkillServices skillServices)
        {
            _skillServices = skillServices;
        }

        [HttpPost]
        public async Task<IActionResult> PostSkill(AddSkillInputModel model)
        {
            await _skillServices.AddAsync(model);

            return Created();
        }

        [HttpPost("PostNote")]
        public async Task<IActionResult> PostNote(AddNoteInputModel model)
        {
            await _skillServices.AddAsyncNote(model);

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> PutSkill(AddSkillInputModel model)
        {
            await _skillServices.UpdateAsync(model);

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetSkill(Guid id)
        {
            return Ok(await _skillServices.GetSkillAsync(id));
        }
    }
}
