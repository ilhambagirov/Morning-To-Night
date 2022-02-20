using M2N.Application.DTOs;
using M2N.Application.Modules.TaskModule;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace M2N.API.Controllers
{
    public class TaskController : BaseApiController
    {
        [HttpGet("{taskCategoryId}")]
        public async Task<IActionResult> GetAll(int taskCategoryId)
        {
            return Ok(await mediatr.Send(new TaskGetAllQuery { TaskCategoryId = taskCategoryId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskDto task)
        {
            await mediatr.Send(new TaskCreateCommand { Task = task });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, TaskEditDto task)
        {
            var response = await mediatr.Send(new TaskEditCommand { Id = id, TaskEditDto = task });
            if (response == 0) return NotFound();

            return Ok();
        }

        [HttpPut("stageUpdate/{taskId}")]
        public async Task<IActionResult> ChangeStage(int taskId, TaskChangeStageDto task)
        {
            var response = await mediatr.Send(new TaskStageEditCommand { Id = taskId, TaskChangeStageDto = task });
            if (response == 0) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediatr.Send(new TaskDeleteCommand { Id = id });
            if (response == 0) return NotFound();

            return Ok();
        }
    }
}
