using MediatR;
using System.Net;
using TaskManager.Application.Abstractions.ResponseModels;
using TaskManager.Application.Commands.UserMange;
using TaskManager.Domain.AggregateModels.UserManage;

namespace TaskManager.Application.CommandHandlers.UserManage
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, CommandHandlerResponse>
    {
        private readonly IAuthAggregateRepository _authAggregateRepository;

        public RegisterUserCommandHandler(IAuthAggregateRepository authAggregateRepository)
        {
            this._authAggregateRepository = authAggregateRepository;
        }
        public async Task<CommandHandlerResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandHandlerResponse();

            try
            {
                var user = await _authAggregateRepository.GetUserByEmail(request.Email.ToLower());
                
                if (user != null)
                {
                    response.SetResponseError("User already exists", HttpStatusCode.BadRequest);
                    return response;
                }

                var aggregate = new AuthAggregate();

                aggregate.CreateUserRegistrationModel(firstName: request.FirstName,
                    lastName: request.LastName,
                    email: request.Email,
                    password: request.Password);

                await this._authAggregateRepository.CreateUser(aggregate.UserRegistrationModel);

                response.SetSuccess();

            }
            catch (Exception ex)
            {

                response.SetResponseError(ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
