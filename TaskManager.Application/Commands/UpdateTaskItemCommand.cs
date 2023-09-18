using MediatR;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class UpdateTaskItemCommand : IRequest<bool>
    {
        public string ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public string[] TaskTags { get; set; }
    }
}
