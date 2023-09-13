using MediatR;
using TaskManager.Application.DTOs.TaskItem;

namespace TaskManager.Application.Requests
{
    public class GetTasksRequest : IRequest<List<TaskItemListDto>>
    {
    }
}
