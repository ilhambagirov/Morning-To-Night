using M2N.Application.DTOs;
using M2N.Application.Modules.TaskCategoryModule;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace M2N.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskCategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(TaskCategoryDto taskCategory)
        {
            await mediatr.Send(new TaskCategoryCreateCommand { TaskCategoryDto = taskCategory });

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediatr.Send(new TaskCategoryGetAllQuery());

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, TaskCategoryDto taskCategory)
        {
            var response = await mediatr.Send(new TaskCategoryEditCommand { Id = id, TaskCategoryDto = taskCategory });
            if (response == 0) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await mediatr.Send(new TaskCategoryDeleteCommand { Id = id });
            if (response == 0) return NotFound();

            return Ok();
        }
    }
}
