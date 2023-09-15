using MongoDB.Bson;
using MongoDB.Driver;
using TaskManager.Domain.AggregateModels.TaskItemAggregate;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.DatabaseContext;

namespace TaskManager.Infrastructure.Repositories
{
    public class TasksAggregateRepository : ITasksAggregateRepository
    {
        private readonly IMongoDbContext _dbContext;

        public TasksAggregateRepository(IMongoDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<(List<TaskItem> data, long totalCount)> GetAllFilteredTaskItems(
            int pageNumber,
            int pageSize,
            string searchedTitleText,
            string sortBy,
            bool sortAscending)
        {
            var filterBuilder = Builders<TaskItem>.Filter;
            var filterDefinition = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(searchedTitleText))
            {
                var regexPattern = new BsonRegularExpression(searchedTitleText, "i");
                filterDefinition &= filterBuilder.Regex("Title", regexPattern);
            }

            SortDefinition<TaskItem>? sort = null;
            if (!string.IsNullOrEmpty(sortBy))
            {
                sort = sortAscending
                    ? Builders<TaskItem>.Sort.Ascending(sortBy)
                    : Builders<TaskItem>.Sort.Descending(sortBy);
            }

            var findOptions = new FindOptions<TaskItem, TaskItem>
            {
                Sort = sort,
                Skip = (pageNumber - 1) * pageSize,
                Limit = pageSize
            };
            var taskCollection = this._dbContext.GetCollection<TaskItem>("TaskItems");

            var filteredTaskItems =  (await taskCollection.FindAsync(filterDefinition, findOptions)).ToList();
            var totalCount = await taskCollection.CountDocumentsAsync(filterDefinition);

            return (filteredTaskItems, totalCount);
        }
    }
}
