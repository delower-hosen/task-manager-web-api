using TaskManager.Domain.Entities;

namespace TaskManager.Domain.AggregateModels.TaskItemAggregate
{
    public interface ITasksAggregateRepository
    {
        Task<(List<TaskItem> data, long totalCount)> GetAllFilteredTaskItems(
            int pageNumber,
            int pageSize,
            string searchedTitleText,
            string sortBy,
            bool sortAscending);
    }
}
