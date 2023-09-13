using TaskManager.Application.DTOs.TaskItem;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.DtoExtensions
{
    public static class TaskItemDtoExtension
    {
        public static TaskItemListDto AsTaskListDto(this TaskItem task)
        {
            return new TaskItemListDto
            {
                ItemId = task._id,
                Title = task.Title,
                Description = task.Description
            };
        }
    }
}
