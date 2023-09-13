using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.TaskItem;
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
        [HttpGet]
        public async Task<ActionResult<List<TaskItemListDto>>> Get()
        {
            var testData = await _mediator.Send(new GetTasksRequest());

            return Ok(testData);
        }

    }
}
