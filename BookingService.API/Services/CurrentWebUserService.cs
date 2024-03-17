using BookingService.Application.Contracts.Presentation;
using System.IdentityModel.Tokens.Jwt;

namespace BookingService.API.Services
{
    public class CurrentWebUserService : ICurrentUserService
    {
        public int? UserId { get => GetUserId(); }
        public string? UserRole { get => GetUserRole(); }
        private string? token { get; set; }

        public CurrentWebUserService(IHttpContextAccessor httpContext)
        {
            token = httpContext.HttpContext?.Items["AccessToken"]?.ToString();
        }
        private int? GetUserId()
        {
            if (token is null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.ReadToken(token) is JwtSecurityToken jsonToken && jsonToken.Subject is not null && int.TryParse(jsonToken.Subject, out var userId))
                return userId;
            return null;
        }
        private string? GetUserRole()
        {
            if (token is null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            if (tokenHandler.ReadToken(token) is JwtSecurityToken jsonToken && jsonToken.Actor is not null)
                return jsonToken.Actor;

            return null;
        }
    }
}
