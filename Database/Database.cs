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
            //modelBuilder.Seed();
        }

    }

    //public static class ModelBuilderExtensions
    //{
    //    public static void Seed(this ModelBuilder modelBuilder)
    //    {

    //        modelBuilder.Entity<Arquivo>().HasData(new Arquivo[]
    //        {
    //            new Arquivo {
    //                Id = 1,
    //                Nome = "Rafael",
    //                Email ="Rafael@gmail.com",
    //                Genero = EGenero.Masculino,
    //                CriadoEm = DateTime.Now
    //            },
    //        });
    //    }
    //}

}
