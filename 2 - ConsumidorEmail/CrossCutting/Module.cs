using _2___ConsumidorEmail.ApplicationService;
using _2___ConsumidorEmail.Services;

namespace _2___ConsumidorEmail.CrossCutting
{
    public static class Module
    {

        public static void RegisterModules(this IServiceCollection service)
        {
            RegisterTransient(service);
            RegisterSingleton(service);
            RegisterScoped(service);
        }

        private static void RegisterTransient(IServiceCollection service) { }

        private static void RegisterSingleton(IServiceCollection service)
        {
        }

        private static void RegisterScoped(IServiceCollection service)
        {
            service.AddScoped<IApplicationServiceEmail, ApplicationServiceEmail>();
            service.AddScoped<IServiceEnvioEmail, ServiceEnvioEmail>();
        }
    }
}
