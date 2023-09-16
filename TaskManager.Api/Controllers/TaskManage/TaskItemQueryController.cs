using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.TaskManage;
using TaskManager.Application.Requests;

namespace TaskManager.Api.Controllers.TaskItem
{
    public class TaskItemQueryController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemQueryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("GetFilteredTaskItems")]
        public async Task<ActionResult<TaskItemListResult>> GetFilteredTaskItems([FromBody] GetFilteredTaskItemsQuery query)
        {
            var testData = await _mediator.Send(query);

            return Ok(testData);
        }

    }
}
