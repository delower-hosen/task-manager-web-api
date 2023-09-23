using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;

namespace TaskManager.Api.Controllers.TaskManage
{
    public class TaskItemCommandController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemCommandController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateTaskItem")]
        [Authorize]
        public async Task<IActionResult> CreateTaskItem(CreateTaskItemCommand taskItemCommand)
        {
            await _mediator.Send(taskItemCommand);
            return Ok("Created task successfully!");
        }

        [HttpPost("UpdateTaskItem")]
        [Authorize]
        public async Task<IActionResult> UpdateTaskItem(UpdateTaskItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated task successfully");
        }

        [HttpPost("DeleteTaskItem")]
        [Authorize]
        public async Task<IActionResult> DeleteTaskItem(DeleteTaskItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Deleted task successfully");
        }
    }
}
