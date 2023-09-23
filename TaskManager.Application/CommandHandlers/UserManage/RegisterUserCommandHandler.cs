using MediatR;
using TaskManager.Application.Commands.UserMange;
using TaskManager.Domain.AggregateModels.UserManage;

namespace TaskManager.Application.CommandHandlers.UserManage
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IAuthAggregateRepository _authAggregateRepository;

        public RegisterUserCommandHandler(IAuthAggregateRepository authAggregateRepository)
        {
            this._authAggregateRepository = authAggregateRepository;
        }
        public Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var aggregate = new AuthAggregate();

            aggregate.CreateUserRegistrationModel(firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                password: request.Password);

            this._authAggregateRepository.CreateUser(aggregate.UserRegistrationModel);

            return Task.FromResult(true);
        }
    }
}
