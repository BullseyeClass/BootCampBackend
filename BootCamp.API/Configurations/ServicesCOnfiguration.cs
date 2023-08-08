using BootCamp.BusinessLogic.Services.Implementations;
using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Repository.Implementation;
using BootCamp.Data.Repository.Interface;

namespace BootCamp.API.Configurations
{
    public static class ServicesCOnfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<ITraineeService, TraineeService>()
                .AddScoped<IAuthentication,  Authentication>()
                .AddScoped<ITokenGenerator, TokenGenerator>();
        }
    }
}
