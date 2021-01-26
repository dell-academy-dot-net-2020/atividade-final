using Dell.Academy.Atividade.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dell.Academy.Atividade.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString($"DefaultConnection@{Environment.MachineName}") ??
                                        configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApiContexto>(opt => opt.UseMySQL(connectionString));
        }
    }
}