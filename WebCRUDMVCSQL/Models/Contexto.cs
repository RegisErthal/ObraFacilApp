using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<ObraFacilApp.Models.Projeto>? Projeto_1 { get; set; }
        public DbSet<Alvenaria> Alvenaria { get; set; }
        public DbSet<Cobertura> Cobertura { get; set; }

        public DbSet<Hidraulica> Hidraulica { get; set; }
        public DbSet<Cronograma> Cronograma { get; set; }
        public DbSet<ObraFacilApp.Models.Fundacao>? Fundacao { get; set; }

        public DbSet<ObraFacilApp.Models.Eletrica>? Eletrica { get; set; }

    }
}
