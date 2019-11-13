using Api.DataAccess.Contracts.Repositories;
using Api.DataAccess.Repositories;
using Coworking.Application.ApiCaller;
using Coworking.Application.Configuration;
using Coworking.Application.Contracts;
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
            AddRegisterOthers(services);

            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IOfficeService, OfficeService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IServicesService, ServicesService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();

            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            services.AddTransient<IAppConfig, AppConfig>();
            services.AddTransient<IApiCaller, ApiCaller>();

            return services;
        }
    }
}