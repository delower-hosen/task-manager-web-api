using TaskManager.Domain.Entities;
using TaskManager.Domain.Services;

namespace TaskManager.Domain.AggregateModels.TaskManage
{
    public class TaskItemAggregate
    {
        public TaskItem? TaskItemInsertModel { get; protected set; }

        public static TaskItemAggregate Create()
        {
            return new TaskItemAggregate();
        }

        public void CreateTaskItemInsertModel(
            string title,
            string description,
            DateTime? dueDate,
            DateTime? completionDate,
            Priority priority,
            Status status,
            string[] tasktags)
        {
            TaskItemInsertModel = new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                CompletionDate = completionDate,
                Priority = priority,
                Status = status,
                TaskTags = tasktags
            };

            TaskItemInsertModel.AddBasicEntityInfo();
        }
    }
}
