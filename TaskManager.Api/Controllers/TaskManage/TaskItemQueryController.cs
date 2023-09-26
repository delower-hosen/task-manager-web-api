using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Abstractions.ResponseModels;
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
        public async Task<ActionResult<QueryHandlerRespnse<List<TaskItemListDto>>>> GetFilteredTaskItems([FromBody] GetFilteredTaskItemsQuery query)
        {
            var filteredTaskList = await _mediator.Send(query);

            return Ok(filteredTaskList);
        }

    }
}
