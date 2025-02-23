using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using online_retail.Services.Interface;

namespace online_retail.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jwtService, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                var userId = jwtService.ValidateJwtToken(token);

                if (userId != null)
                {
                    context.Items["User"] = await userService.GetById(userId.Value);  
                }
            }

            await _next(context);
        }
    }
}
