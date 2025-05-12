using BusinessRules.BusinessRules;
using BusinessRules.Interface;
using DataAccess.Interface;
using DataAccess.Repository;

namespace BuildingApi.Config
{
    public static class ConfigDependency
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPropertyTraceService, PropertyTraceService>();
            services.AddTransient<IPropertyImageService, PropertyImageService>();

            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPropertyTraceRepository, PropertyTraceRepository>();
            services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();

            return services;
        }
    }
}
