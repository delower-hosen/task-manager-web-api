using TaskManager.Domain.Entities;
using TaskManager.Domain.Services;

namespace TaskManager.Domain.AggregateModels.UserManage
{
    public class AuthAggregate
    {
        public User? UserRegistrationModel { get; protected set; }
        public User? CurrentUser { get; protected set; }
        public bool HasValidCredential { get; protected set; } = false;
        public static AuthAggregate Create()
        {
            return new AuthAggregate();
        }

        public void CreateUserRegistrationModel(string firstName,
            string lastName, string email, string password)
        {
            UserRegistrationModel = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            UserRegistrationModel.AddBasicEntityInfo();
        }

        public void SetCurrentUser(User user) => CurrentUser = user;

        public void ValidateCredential(string password)
        {

            if (CurrentUser != null)
            {
                HasValidCredential = BCrypt.Net.BCrypt.Verify(password, CurrentUser.PasswordHash);
            }

        }

        public static string GenerateToken(string email, string password)
        {
            return string.Empty;
        }

    }
}
