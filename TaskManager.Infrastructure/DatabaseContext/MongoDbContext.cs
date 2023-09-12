using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace TaskManager.Infrastructure.DatabaseContext
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var client = new MongoClient(connectionString);
            var database = configuration.GetConnectionString("DatabaseName");
            _database = client.GetDatabase(database);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
