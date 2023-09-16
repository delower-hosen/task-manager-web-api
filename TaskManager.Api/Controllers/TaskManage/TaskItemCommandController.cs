using MediatR;
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
        public async Task<IActionResult> CreateTaskItem(CreateTaskItemCommand taskItemCommand)
        {
            await _mediator.Send(taskItemCommand);
            return Ok("Created task successfully!");
        }
    }
}
