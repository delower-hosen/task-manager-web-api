using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Domain.AggregateModels.UserManage;
using TaskManager.Domain.Configs;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.DatabaseContext;

namespace TaskManager.Infrastructure.Repositories
{
    public class AuthAggregateRepository : IAuthAggregateRepository
    {
        private readonly IMongoDbContext _dbContext;
        private readonly ICustomAppConfigProvider _configuration;

        public AuthAggregateRepository(IMongoDbContext dbContext,
            ICustomAppConfigProvider configuration)
        {
            this._dbContext = dbContext;
            this._configuration = configuration;
        }

        public async Task CreateUser(User user)
        {
            var userCollection = this._dbContext.GetCollection<User>(typeof(User).Name + "s");

            await userCollection
                .InsertOneAsync(user);
        }

        public Task<string> GenerateToken(string email, string password)
        {
            var secret = _configuration.GetJwtTokenSecret();
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            return Task.FromResult(tokenString);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var filterBuilder = Builders<User>.Filter;
            var filter = filterBuilder.Eq(x => x.Email, email);

            var findOptions = new FindOptions<User, User>
            {
                Skip = 0,
                Limit = 10
            };

            var userCollection = this._dbContext.GetCollection<User>(typeof(User).Name + "s");

            var user = (await userCollection.FindAsync(filter, findOptions)).SingleOrDefault();

            return user;
        }
    }
}
