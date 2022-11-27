using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PriceBuddy.Api.Services;
using PriceBuddy.Data;
using PriceBuddy.Data.Repositories;
using System.Text;

namespace PriceBuddy.Api.Configuration;

public static class Configuration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();

        var key = Encoding.ASCII.GetBytes(Secret.Random(30).ToString());
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<TokenService>();

        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<ProductRepository>();
        services.AddTransient<UserRepository>();

        return services;
    }

    public static IServiceCollection ConfigureContexts(this IServiceCollection services, string user, string dbPwd)
    {
        services.AddDbContext<PriceBuddyDbContext>(options =>
        options.UseSqlServer($"Data Source=localhost;Initial Catalog=PriceBuddyDb;User ID={user};Password={dbPwd};Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

        return services;
    }
}
