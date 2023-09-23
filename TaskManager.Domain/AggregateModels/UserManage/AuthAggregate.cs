using TaskManager.Domain.Entities;
using TaskManager.Domain.Services;

namespace TaskManager.Domain.AggregateModels.UserManage
{
    public class AuthAggregate
    {
        public User? UserRegistrationModel { get; protected set; }
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

    }
}
