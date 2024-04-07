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
            base.OnModelCreating(modelBuilder);
        }

    }

}
