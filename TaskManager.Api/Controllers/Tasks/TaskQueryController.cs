using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Application.Requests;

namespace TaskManager.Api.Controllers.Task
{
    public class TaskQueryController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public TaskQueryController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskListDto>>> Get()
        {
            var testData = await _mediator.Send(new GetTasksRequest());

            return Ok(testData);
        }

    }
}
