using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
