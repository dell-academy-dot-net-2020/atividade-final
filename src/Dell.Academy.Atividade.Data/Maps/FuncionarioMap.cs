using Dell.Academy.Atividade.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.Academy.Atividade.Data.Maps
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.NomeCompleto).HasMaxLength(100).IsRequired();
            builder.Property(f => f.DataNascimento).IsRequired();
            builder.Property(f => f.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(f => f.Sexo).IsRequired();
            builder.HasOne(f => f.Endereco).WithOne(e => e.Funcionario);
        }
    }
}