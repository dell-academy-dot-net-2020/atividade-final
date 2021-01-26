using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dell.Academy.Atividade.Api.Configurations
{
    public static class DependenceInjectionConfig
    {
        public static void AddDependenceInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
        }
    }
}