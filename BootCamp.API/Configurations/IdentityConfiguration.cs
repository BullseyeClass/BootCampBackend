using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace BootCamp.API.Configurations
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Trainee, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                //options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<MyAppContext>()
            .AddDefaultTokenProviders();

            // Optionally, you can configure other Identity settings here if needed.
        }
    }
}
