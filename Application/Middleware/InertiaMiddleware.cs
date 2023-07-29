using InertiaCore;
using InertiaSparkTest.Application.Models;
using InertiaSparkTest.Application.Services.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Security.Claims;

namespace InertiaSparkTest.Application.Middleware
{
    public class InertiaMiddleware
    {
        private readonly RequestDelegate _next;

        public InertiaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // users
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                var userRoles = new List<string>();
                var rolesQuery = context.User.FindAll(ClaimTypes.Role).ToList();
                foreach (var role in rolesQuery)
                {
                    userRoles.Add(role.Value);
                }
                var user = new
                {
                    Id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    Name = context.User.FindFirst(ClaimTypes.Name)?.Value,
                    Email = context.User.FindFirst(ClaimTypes.Email)?.Value,
                    Roles = userRoles
                };
                Inertia.Share("auth", new Dictionary<string, object?> {
                    {"user", user },
                    {"isAuthenticated", true }
                });
            }
            else
            {
                Inertia.Share("auth", new Dictionary<string, object?> {
                    {"user", null },
                    {"isAuthenticated", false }
                });
            }
            // errors
            // flash

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }

    public static class InertiaMiddlewareExtensions
    {
        public static IApplicationBuilder UseInertiaSharedProps(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InertiaMiddleware>();
        }
    }
}
