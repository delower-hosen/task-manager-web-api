using MediatR;
using TaskManager.Application.DTOs.TaskManage;

namespace TaskManager.Application.Requests
{
    public class GetFilteredTaskItemsQuery : IRequest<TaskItemListResult>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchedTitleText { get; set; }
        public string SortBy { get; set; } = "Title";
        public bool SortAscending { get; set; }
    }
}
