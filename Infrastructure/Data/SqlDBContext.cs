using Microsoft.EntityFrameworkCore;
using Org.Domain.Data.Model;

namespace Org.Infrestructure.Data
{
    public class SqlDBConttext : DbContext
    {
        public SqlDBConttext(DbContextOptions<SqlDBConttext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>()
            .HasMany(c => c.Clientes)
            .WithOne(e => e.Agencia);
        }
    }
}