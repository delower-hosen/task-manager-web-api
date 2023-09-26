using MediatR;
using System.Net;
using TaskManager.Application.Abstractions.ResponseModels;
using TaskManager.Application.DtoExtensions;
using TaskManager.Application.DTOs.TaskManage;
using TaskManager.Application.Requests;
using TaskManager.Domain.AggregateModels.TaskManage;

namespace TaskManager.Application.QueryHandlers.TaskItem
{
    public class GetTaskItemsRequestHandler : IRequestHandler<GetFilteredTaskItemsQuery, QueryHandlerRespnse<List<TaskItemListDto>>>
    {
        private readonly ITaskItemAggregateRepository _tasksAggregateRepository;

        public GetTaskItemsRequestHandler(ITaskItemAggregateRepository tasksAggregateRepository)
        {
            this._tasksAggregateRepository = tasksAggregateRepository;
        }
        public async Task<QueryHandlerRespnse<List<TaskItemListDto>>> Handle(GetFilteredTaskItemsQuery query, CancellationToken cancellationToken)
        {
            var response = new QueryHandlerRespnse<List<TaskItemListDto>>();
            try
            {
                var searchedResult = await this._tasksAggregateRepository.GetAllFilteredTaskItems(
                pageNumber: query.PageNumber,
                pageSize: query.PageSize,
                searchedTitleText: query.SearchedTitleText,
                sortBy: query.SortBy,
                sortAscending: query.SortAscending);

                var taskListDtos = searchedResult.data.Select(task => task.AsTaskListDto()).ToList();
                var totalCount = searchedResult.totalCount;

                response.SetSuccess(taskListDtos, totalCount);
            }
            catch (Exception ex)
            {

                response.SetResponseError(ex.Message, HttpStatusCode.InternalServerError);
            }
            return response;
        }
    }
}
