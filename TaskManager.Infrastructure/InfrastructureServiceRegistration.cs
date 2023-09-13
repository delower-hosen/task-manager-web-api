using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.AggregateModels.TaskItemAggregate;
using TaskManager.Infrastructure.DatabaseContext;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigurInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.AddScoped<ITasksAggregateRepository, TasksAggregateRepository>();
            return services;
        }
    }
}
