using TaskManager.Domain.Entities;

namespace TaskManager.Domain.AggregateModels.TaskItemAggregate
{
    public interface ITasksAggregateRepository
    {
        Task<List<TaskItem>> GetAllTaskItems();
    }
}
