using ApiMyArquivos.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMyArquivos.Database
{
    public class DatabaseAPI : DbContext
    {
        public DatabaseAPI(DbContextOptions<DatabaseAPI> options) : base(options) { }

        public DbSet<Arquivo> Arquivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arquivo>().Property(p => p.Titulo).HasMaxLength(100);
            modelBuilder.Entity<Arquivo>().HasIndex(p => p.Titulo).IsUnique(true);
            modelBuilder.Entity<Arquivo>().Property(p => p.Descricao).HasMaxLength(2000);

            base.OnModelCreating(modelBuilder);
        }
    }

}
