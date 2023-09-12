using MediatR;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Application.Requests;

namespace TaskManager.Application.QueryHandlers.Tasks
{
    public class GetTasksRequestHandler : IRequestHandler<GetTasksRequest, List<TaskListDto>>
    {
        public Task<List<TaskListDto>> Handle(GetTasksRequest request, CancellationToken cancellationToken)
        {
            List<TaskListDto> taskList = new()
            {
                new TaskListDto
                {
                    ItemId = Guid.NewGuid().ToString(),
                    Title = "Complete report",
                    Description = "Write the final report for the project."
                },
                new TaskListDto
                {
                    ItemId = Guid.NewGuid().ToString(),
                    Title = "Code review",
                    Description = "Review and provide feedback on the latest code changes."
                }
            };

            return Task.FromResult(taskList);
        }
    }
}
