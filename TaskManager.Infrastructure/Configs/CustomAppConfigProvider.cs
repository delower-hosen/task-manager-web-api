using Microsoft.Extensions.Configuration;
using TaskManager.Domain.Configs;

namespace TaskManager.Infrastructure.Configs
{
    public class CustomAppConfigProvider : ICustomAppConfigProvider
    {
        private readonly IConfiguration _configuration;

        public CustomAppConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJwtTokenSecret()
        {
            var secret = _configuration.GetSection("JwtSettings:Secret")?.Value ?? "default_secret";

            return secret;
        }
    }
}
