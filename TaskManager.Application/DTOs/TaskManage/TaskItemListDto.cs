using TaskManager.Domain.Entities;

namespace TaskManager.Application.DTOs.TaskManage
{
    public class TaskItemListDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string[] Tags { get; set; }
        public string Description { get; set; }
        public Status? Status { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string[] TaskTags { get; set; }

    }
}
