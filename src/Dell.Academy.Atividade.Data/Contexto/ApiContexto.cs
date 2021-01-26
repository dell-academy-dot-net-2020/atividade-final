using Dell.Academy.Atividade.Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dell.Academy.Atividade.Data.Contexto
{
    public class ApiContexto : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public ApiContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApiContexto)));
            base.OnModelCreating(modelBuilder);
        }
    }
}