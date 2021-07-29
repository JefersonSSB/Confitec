using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infrastructure.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.DataNascimento).IsRequired();

        }

    }
}