using TaskManager.Application.DTOs.TaskManage;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.DtoExtensions
{
    public static class TaskItemDtoExtension
    {
        public static TaskItemListDto AsTaskListDto(this TaskItem task)
        {
            return new TaskItemListDto
            {
                ItemId = task.ItemId,
                CreateDate = task.CreateDate,
                Tags = task.Tags,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.Value,
                Priority = task.Priority.Value,
                DueDate = task.DueDate,
                CompletionDate = task.CompletionDate,
                TaskTags = task.TaskTags
            };
        }
    }
}
