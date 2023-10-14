using TaskManager.Domain.Entities;

namespace TaskManager.Domain.AggregateModels.UserManage
{
    public interface IAuthAggregateRepository
    {
        Task CreateUser(User? user);
        Task<string> GenerateToken(string email, string password);
        Task<User> GetUserByEmail(string email);
    }
}
