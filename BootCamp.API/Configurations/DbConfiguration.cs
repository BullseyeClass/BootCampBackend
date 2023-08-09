using BootCamp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BootCamp.API.Configurations
{
    public static class DbConfiguration
    {
        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyAppContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
