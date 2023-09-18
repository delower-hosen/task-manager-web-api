using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Domain.AggregateModels.TaskManage;

namespace TaskManager.Application.CommandHandlers.TaskManage
{
    public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand, bool>
    {
        private readonly ITaskItemAggregateRepository _taskItemAggregateRepository;

        public UpdateTaskItemCommandHandler(ITaskItemAggregateRepository taskItemAggregateRepository)
        {
            this._taskItemAggregateRepository = taskItemAggregateRepository;
        }
        public Task<bool> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            this._taskItemAggregateRepository.UpdateTaskItem(itemId: request.ItemId,
                title: request.Title,
                description: request.Description,
                dueDate: request.DueDate,
                completionDate: request.CompletionDate,
                priority: request.Priority,
                status: request.Status);

            return Task.FromResult(true);
        }
    }
}
