using TaskManager.Domain.Entities;

namespace TaskManager.Domain.AggregateModels.Tasks
{
    public interface ITasksAggregateRepository
    {
        Task<List<TaskItem>> GetAllTaskRecords();
    }
}
