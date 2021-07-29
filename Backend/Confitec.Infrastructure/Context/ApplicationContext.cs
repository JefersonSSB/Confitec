
using System;
using Confitec.Domain.Entities;
using Confitec.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;




namespace Confitec.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
         : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Escolaridade> Escolaridade { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new EscolaridadeConfiguration());
        }
    }
}