using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Domain.AggregateModels.UserManage;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.DatabaseContext;

namespace TaskManager.Infrastructure.Repositories
{
    public class AuthAggregateRepository : IAuthAggregateRepository
    {
        private readonly IMongoDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthAggregateRepository(IMongoDbContext dbContext,
            IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._configuration = configuration;
        }

        public async Task CreateUser(User user)
        {
            var userCollection = this._dbContext.GetCollection<User>("Users");

            await userCollection
                .InsertOneAsync(user);
        }

        public Task<string> LoginUser(string email, string password)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("JwtSettings:Secret").Value));

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
    }
}
