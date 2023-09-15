namespace TaskManager.Application.DTOs.TaskItem
{
    public sealed class TaskItemListResult
    {
        public List<TaskItemListDto> TaskItems { get; set; }
        public long TotalCount { get; set; }

        public TaskItemListResult(List<TaskItemListDto> taskItems, long totalCount)
        {
            TaskItems = taskItems;
            TotalCount = totalCount;
        }
    }
}
