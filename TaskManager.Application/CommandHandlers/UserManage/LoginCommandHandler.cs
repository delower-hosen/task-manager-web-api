using MediatR;
using System.Net;
using TaskManager.Application.Abstractions.ResponseModels;
using TaskManager.Application.Commands.UserMange;
using TaskManager.Application.DTOs.UserManage;
using TaskManager.Domain.AggregateModels.UserManage;

namespace TaskManager.Application.CommandHandlers.UserManage
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, QueryHandlerRespnse<LoginResponseDto>>
    {
        private readonly IAuthAggregateRepository _authAggregateRepository;

        public LoginCommandHandler(IAuthAggregateRepository authAggregateRepository)
        {
            this._authAggregateRepository = authAggregateRepository;
        }
        public async Task<QueryHandlerRespnse<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new QueryHandlerRespnse<LoginResponseDto>();

            try
            {
                var currentUser = await _authAggregateRepository.GetUserByEmail(request.Email);

                var aggregate = new AuthAggregate();
                aggregate.SetCurrentUser(currentUser);

                aggregate.ValidateCredential(request.Password);

                if (!aggregate.HasValidCredential)
                {
                    response.SetResponseError("Incorrect credential", HttpStatusCode.BadRequest);
                    return response;
                }
                var token = await _authAggregateRepository.GenerateToken(request.Email, request.Password);

                var result = new LoginResponseDto(accessToken: token);

                response.SetSuccess(result);

            }
            catch (Exception ex)
            {

                response.SetResponseError(ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
