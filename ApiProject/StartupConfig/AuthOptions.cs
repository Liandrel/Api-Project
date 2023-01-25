using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiProject.StartupConfig;

public static class AuthOptions
{
    public static void AddAuthorizationOptions(AuthorizationOptions opts)
    {
        opts.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
    }

    public static void AddJwtBearerOptions(WebApplicationBuilder? builder, JwtBearerOptions opts)
    {
        opts.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
            ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(
                                    Encoding.ASCII.GetBytes(
                                        builder.Configuration.GetValue<string>("Authentication:SecretKey")))
    };
    }
}
