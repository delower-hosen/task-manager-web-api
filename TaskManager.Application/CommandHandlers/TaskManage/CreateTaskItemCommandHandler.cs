using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Domain.AggregateModels.TaskManage;

namespace TaskManager.Application.CommandHandlers.TaskManage
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, bool>
    {
        private readonly ITaskItemAggregateRepository _taskItemAggregateRepository;

        public CreateTaskItemCommandHandler(ITaskItemAggregateRepository taskItemAggregateRepository)
        {
            this._taskItemAggregateRepository = taskItemAggregateRepository;
        }
        public async Task<bool> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var aggregate = TaskItemAggregate.Create();
            aggregate.CreateTaskItemInsertModel(title: request.Title,
                description: request.Description,
                status: request.Status.Value,
                priority: request.Priority.Value,
                dueDate: request.DueDate,
                completionDate: request.CompletionDate,
                tasktags: request.TaskTags);

            await this._taskItemAggregateRepository.CreateTaskItem(aggregate);

            return await Task.FromResult(true);
        }
    }
}
