using TaskManager.Domain.Entities;

namespace TaskManager.Domain.AggregateModels.UserManage
{
    public interface IAuthAggregateRepository
    {
        Task CreateUser(User? user);
        Task<string> LoginUser(string email, string password);
        Task<User> GetExistingUser(string email);
    }
}
