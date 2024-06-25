using _1___Publicador.ApplicationService;
using _1___Publicador.Repository;
using MassTransit;

namespace _1___Publicador.CrossCutting
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
            service.AddSingleton<IRepositoryChamado, RepositoryChamado>();
        }

        private static void RegisterScoped(IServiceCollection service)
        {
            service.AddScoped<IApplicationServiceChamado, ApplicationServiceChamado>();
            service.AddScoped<IRepositoryChamado, RepositoryChamado>();
        }
    }
}
