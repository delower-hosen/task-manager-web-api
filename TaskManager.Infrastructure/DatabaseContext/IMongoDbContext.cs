using MongoDB.Driver;

namespace TaskManager.Infrastructure.DatabaseContext
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
