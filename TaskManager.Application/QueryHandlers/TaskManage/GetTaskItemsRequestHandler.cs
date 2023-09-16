using MediatR;
using TaskManager.Application.DtoExtensions;
using TaskManager.Application.DTOs.TaskManage;
using TaskManager.Application.Requests;
using TaskManager.Domain.AggregateModels.TaskManage;

namespace TaskManager.Application.QueryHandlers.TaskItem
{
    public class GetTaskItemsRequestHandler : IRequestHandler<GetFilteredTaskItemsQuery, TaskItemListResult>
    {
        private readonly ITaskItemAggregateRepository _tasksAggregateRepository;

        public GetTaskItemsRequestHandler(ITaskItemAggregateRepository tasksAggregateRepository)
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
