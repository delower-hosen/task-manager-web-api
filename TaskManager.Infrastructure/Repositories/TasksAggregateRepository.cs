﻿using MongoDB.Driver;
using TaskManager.Domain.AggregateModels.Tasks;
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
        public async Task<List<TaskItem>> GetAllTaskRecords()
        {
            var taskCollection = this._dbContext.GetCollection<TaskItem>("TaskItems");

            return (await taskCollection.FindAsync(FilterDefinition<TaskItem>.Empty)).ToList();
        }
    }
}
