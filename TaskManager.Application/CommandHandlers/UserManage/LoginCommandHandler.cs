using MediatR;
using TaskManager.Application.Commands.UserMange;
using TaskManager.Application.DTOs.UserManage;
using TaskManager.Domain.AggregateModels.UserManage;

namespace TaskManager.Application.CommandHandlers.UserManage
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IAuthAggregateRepository _authAggregateRepository;

        public LoginCommandHandler(IAuthAggregateRepository authAggregateRepository)
        {
            this._authAggregateRepository = authAggregateRepository;
        }
        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _authAggregateRepository.LoginUser(email: request.Email,
                password: request.Password);

            var response = new LoginResponseDto(accessToken: token);

            return response;
        }
    }
}
