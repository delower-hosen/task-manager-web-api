using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Abstractions.ResponseModels;
using TaskManager.Application.Commands.UserMange;
using TaskManager.Application.DTOs.UserManage;

namespace TaskManager.Api.Controllers.UserManage.Auth
{
    public class AuthController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<CommandHandlerResponse>> RegisterUser(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction("RegisterUser", new { }, response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<QueryHandlerRespnse<LoginResponseDto>>> Login(LoginCommand command)
        {
            var reponse = await _mediator.Send(command);
            return Ok(reponse);
        }
    }
}
