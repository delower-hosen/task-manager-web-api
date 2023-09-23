using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskManager.Application.DTOs.UserManage;

namespace TaskManager.Application.Commands.UserMange
{
    public class LoginCommand : IRequest<LoginResponseDto>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
