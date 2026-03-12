using Aplication;
using Aplication.IServices;
using Dominio.IRepository;
using Insfrastructure.Context;
using Insfrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Configuration
{
    public static class InjeicaoIdenpendenciaEBancoDados
    {
        public static void BancoDados(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<Context>(options =>
         options.UseSqlServer(
             configuration.GetConnectionString("DataBase"),
             x => x.MigrationsAssembly("Insfrastructure")
         ));
        }

        public static void RegistrarServicosrRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAssinanteRepository, AssinanteRepository>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IAssinanteService, AssinanteServices>();
        }
    }
}
