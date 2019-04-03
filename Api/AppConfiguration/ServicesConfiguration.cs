using Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api.AppConfiguration
{
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Configure Dependency Injection: Skeleton | Transient | Scoped
        /// Reference: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServiceCollection, ServiceCollection>();
            services.AddScoped<IDateTimeService, DateTimeService>();
            // services.AddScoped<ILoggerService, LoggerService>();
        }

        /// <summary>
        /// COnfiguration of MVC JSON Options
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureMvcAndJson(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.None;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                // Date formatting in JSON if needed:
                // options.SerializerSettings.DateFormatString = "MM/dd/yyyy";
            });
        }
    }
}
