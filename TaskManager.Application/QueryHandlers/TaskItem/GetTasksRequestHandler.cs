using MediatR;
using TaskManager.Application.DtoExtensions;
using TaskManager.Application.DTOs.TaskItem;
using TaskManager.Application.Requests;
using TaskManager.Domain.AggregateModels.TaskItemAggregate;

namespace TaskManager.Application.QueryHandlers.TaskItem
{
    public class GetTasksRequestHandler : IRequestHandler<GetTasksRequest, List<TaskItemListDto>>
    {
        private readonly ITasksAggregateRepository _tasksAggregateRepository;

        public GetTasksRequestHandler(ITasksAggregateRepository tasksAggregateRepository)
        {
            this._tasksAggregateRepository = tasksAggregateRepository;
        }
        public async Task<List<TaskItemListDto>> Handle(GetTasksRequest request, CancellationToken cancellationToken)
        {
            var taskItems = await this._tasksAggregateRepository.GetAllTaskItems();
            var taskListDtos = taskItems.Select(task => task.AsTaskListDto()).ToList();

            return taskListDtos;
        }
    }
}
