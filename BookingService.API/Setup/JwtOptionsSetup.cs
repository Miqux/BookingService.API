using BookingService.Infrastructure.Security;
using Microsoft.Extensions.Options;

namespace BookingService.API.Setup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(JwtOptions options)
        {
            configuration.GetSection(SectionName).Bind(options);
        }
    }
}
