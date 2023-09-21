using MediatR;

namespace TaskManager.Application.Commands
{
    public class DeleteTaskItemCommand : IRequest<bool>
    {
        public string? TaskItemId { get; set; }
    }
}
