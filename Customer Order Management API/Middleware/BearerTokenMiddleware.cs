using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class BearerTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public BearerTokenMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        // Skip token validation if [AllowAnonymous] is present
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            await _next(context);
            return;
        }

        // Skip token validation for Swagger or specific endpoints
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = 400;  // Bad Request
            await context.Response.WriteAsync("Missing or empty token.");
            return;
        }

        if (!context.Request.Headers["Authorization"].ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            context.Request.Headers["Authorization"] = "Bearer " + token;
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidAudience = _configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };

            tokenHandler.ValidateToken(token, tokenValidationParams, out var validatedToken);
            context.Items["User"] = validatedToken;
        }
        catch (SecurityTokenException ex)
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync($"Token validation failed: {ex.Message}");
            return;
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync($"An error occurred while processing the token: {ex.Message}");
            return;
        }

        await _next(context);
    }

}
