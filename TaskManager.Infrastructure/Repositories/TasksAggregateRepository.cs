using MongoDB.Bson;
using MongoDB.Driver;
using TaskManager.Domain.AggregateModels.TaskManage;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.DatabaseContext;

namespace TaskManager.Infrastructure.Repositories
{
    public class TasksAggregateRepository : ITaskItemAggregateRepository
    {
        private readonly IMongoDbContext _dbContext;

        public TasksAggregateRepository(IMongoDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task CreateTaskItem(TaskItemAggregate aggregate)
        {
            var taskCollection = this._dbContext.GetCollection<TaskItem>("TaskItems");

            await taskCollection
                .InsertOneAsync(aggregate.TaskItemInsertModel);
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

        public async Task UpdateTaskItem(string itemId,
            string title,
            string description,
            DateTime? dueDate,
            DateTime? completionDate,
            Priority? priority,
            Status? status)
        {
            var updateDefinition = Builders<TaskItem>.Update
                .Set(x => x.Title, title)
                .Set(x => x.Description, description)
                .Set(x => x.DueDate, dueDate)
                .Set(x => x.CompletionDate, completionDate);

            var taskCollection = this._dbContext.GetCollection<TaskItem>("TaskItems");

            await taskCollection.UpdateOneAsync<TaskItem>(x => x.ItemId == itemId, updateDefinition); ;
        }
    }
}
