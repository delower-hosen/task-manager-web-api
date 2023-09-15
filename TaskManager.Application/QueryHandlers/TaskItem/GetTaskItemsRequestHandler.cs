using MediatR;
using TaskManager.Application.DtoExtensions;
using TaskManager.Application.DTOs.TaskItem;
using TaskManager.Application.Requests;
using TaskManager.Domain.AggregateModels.TaskItemAggregate;

namespace TaskManager.Application.QueryHandlers.TaskItem
{
    public class GetTaskItemsRequestHandler : IRequestHandler<GetFilteredTaskItemsQuery, TaskItemListResult>
    {
        private readonly ITasksAggregateRepository _tasksAggregateRepository;

        public GetTaskItemsRequestHandler(ITasksAggregateRepository tasksAggregateRepository)
        {
            this._tasksAggregateRepository = tasksAggregateRepository;
        }
        public async Task<TaskItemListResult> Handle(GetFilteredTaskItemsQuery query, CancellationToken cancellationToken)
        {
            var searchedResult = await this._tasksAggregateRepository.GetAllFilteredTaskItems(
                pageNumber: query.PageNumber,
                pageSize: query.PageSize,
                searchedTitleText: query.SearchedTitleText,
                sortBy: query.SortBy,
                sortAscending: query.SortAscending);

            var taskListDtos = searchedResult.data.Select(task => task.AsTaskListDto()).ToList();
            var totalCount = searchedResult.totalCount;

            var result = new TaskItemListResult(taskListDtos, totalCount);

            return result;
        }
    }
}
