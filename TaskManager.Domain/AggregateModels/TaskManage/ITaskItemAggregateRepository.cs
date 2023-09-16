using TaskManager.Domain.Entities;

namespace TaskManager.Domain.AggregateModels.TaskManage
{
    public interface ITaskItemAggregateRepository
    {
        Task<(List<TaskItem> data, long totalCount)> GetAllFilteredTaskItems(
            int pageNumber,
            int pageSize,
            string searchedTitleText,
            string sortBy,
            bool sortAscending);

        Task CreateTaskItem(TaskItemAggregate aggregate);
    }
}
