using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infrastructure.Configuration
{
    public class EscolaridadeConfiguration : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("Escolaridade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");


            builder.HasData(
                new { Id = 1, Descricao = "Infantil" },
                new { Id = 2, Descricao = "Fundamental" },
                new { Id = 3, Descricao = "Médio" },
                new { Id = 4, Descricao = "Superior" }
          );
        }
     
    }
}