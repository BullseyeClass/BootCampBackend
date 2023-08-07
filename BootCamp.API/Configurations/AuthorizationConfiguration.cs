using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Text;
using cst = BootCamp.BusinessLogic.Utilities;

namespace BootCamp.API.Configurations
{
    public static class AuthorizationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JWTSettings:Audience"],
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
                    options.AddPolicy("RequireAdminOnly", policy => policy.RequireRole(cst.Constants.Roles.Admin)))
                .AddAuthorization(options => options.AddPolicy("RequireCustomerOnly", policy => policy.RequireRole(cst.Constants.Roles.Trainee)));
        }

    }
}
