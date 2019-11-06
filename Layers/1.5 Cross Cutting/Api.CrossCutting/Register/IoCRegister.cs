using Api.DataAccess.Contracts.Repositories;
using Api.DataAccess.Repositories;
using Coworking.Application.Contracts.Services;
using Coworking.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Register
{
    // IoC => Invertion of Control
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);

            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}