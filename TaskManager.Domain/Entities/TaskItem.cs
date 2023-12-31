﻿
namespace TaskManager.Domain.Entities
{
    public class TaskItem : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
        public string[] TaskTags { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        ToDo,
        InProgress,
        InReview,
        Done
    }
}
