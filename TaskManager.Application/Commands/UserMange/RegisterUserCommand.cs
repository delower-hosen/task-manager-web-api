using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.Commands.UserMange
{
    public class RegisterUserCommand : IRequest<bool>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
