using MediatR;
using TaskManager.Application.DTOs.Tasks;

namespace TaskManager.Application.Requests
{
    public class GetTasksRequest : IRequest<List<TaskListDto>>
    {
    }
}
