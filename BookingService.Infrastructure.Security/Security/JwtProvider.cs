using BookingService.Application.Contracts.Security;
using BookingService.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingService.Infrastructure.Security
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }
        public string Generate(User user)
        {
            var claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Actort, user.Role.ToString())
            };

            var signingCredentaials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(options.SecretKey)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                claims,
                null,
                DateAndTime.Now.AddMinutes(options.DurationInMinutes),
                signingCredentaials
            );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
