using System.Reflection;

namespace clean_code_refactor
{
    public static class DependencyInjectionExtensions
    {
        public static void ScanDependencyInjection(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(x => x.GetInterfaces().Any(i => i.Name.EndsWith("Repository") || i.Name.EndsWith("Service")));

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    foreach (var inter in interfaces)
                        services.AddScoped(inter, type);
                }
            }
        }
    }
}
