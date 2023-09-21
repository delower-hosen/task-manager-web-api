using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Domain.AggregateModels.TaskManage;

namespace TaskManager.Application.CommandHandlers.TaskManage
{
    public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand, bool>
    {
        private readonly ITaskItemAggregateRepository _taskItemAggregateRepository;

        public DeleteTaskItemCommandHandler(ITaskItemAggregateRepository taskItemAggregateRepository)
        {
            this._taskItemAggregateRepository = taskItemAggregateRepository;
        }
        public async Task<bool> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            await _taskItemAggregateRepository.DeleteTaskItem(request.TaskItemId);
            return await Task.FromResult(true);
        }
    }
}
