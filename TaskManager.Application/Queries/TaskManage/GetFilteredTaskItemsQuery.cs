using MediatR;
using TaskManager.Application.Abstractions.ResponseModels;
using TaskManager.Application.DTOs.TaskManage;

namespace TaskManager.Application.Requests
{
    public class GetFilteredTaskItemsQuery : IRequest<QueryHandlerRespnse<List<TaskItemListDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchedTitleText { get; set; } = string.Empty;
        public string SortBy { get; set; } = "Title";
        public bool SortAscending { get; set; }
    }
}
