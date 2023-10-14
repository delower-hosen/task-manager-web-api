using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskManager.Application.Abstractions.ResponseModels;
using TaskManager.Application.DTOs.UserManage;

namespace TaskManager.Application.Commands.UserMange
{
    public class LoginCommand : IRequest<QueryHandlerRespnse<LoginResponseDto>>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
