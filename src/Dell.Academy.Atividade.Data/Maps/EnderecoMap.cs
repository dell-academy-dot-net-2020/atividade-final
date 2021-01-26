using Dell.Academy.Atividade.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.Academy.Atividade.Data.Maps
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Rua).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Numero).IsRequired();
            builder.Property(e => e.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Cep).IsRequired().HasMaxLength(8);
            builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Estado).IsRequired().HasMaxLength(2);
            builder.HasOne(e => e.Funcionario).WithOne(f => f.Endereco).HasForeignKey<Endereco>(e => e.FuncionarioId);
        }
    }
}