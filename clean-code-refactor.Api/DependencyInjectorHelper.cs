using clean_code_refactor.Dal;
using clean_code_refactor.Dal.Repositories.Base;
using clean_code_refactor.Domain.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace clean_code_refactor
{
    public static class DependencyInjectorHelper
    {
        public static void AddInfraSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString")));

            services.ScanDependencyInjection(
                typeof(BaseService<,>).Assembly,
                typeof(BaseRepository<>).Assembly
            );
        }
    }
}
