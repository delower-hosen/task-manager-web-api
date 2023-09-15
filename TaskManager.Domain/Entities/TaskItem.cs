
namespace TaskManager.Domain.Entities
{
    public class TaskItem : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public TaskPriority? Priority { get; set; }
        public TaskStatus? Status { get; set; }
        public string[] TaskTags { get; set; }
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        InReview,
        Done
    }
}
