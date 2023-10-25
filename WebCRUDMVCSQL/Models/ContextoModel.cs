﻿using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Map;

namespace ObraFacilApp.Models
{
    public class ContextoModel : DbContext
    {
        public ContextoModel(DbContextOptions<ContextoModel> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ProjetoModel> Projeto { get; set; }
        public DbSet<LoginModel> Login { get; set; }
        public DbSet<AlvenariaModel> Alvenaria { get; set; }
        public DbSet<CoberturaModel> Cobertura { get; set; }

        public DbSet<HidraulicaModel> Hidraulica { get; set; }
        public DbSet<CronogramaModel> Cronograma { get; set; }
        public DbSet<ImagensModel> Imagens { get; set; }
        public DbSet<ObraFacilApp.Models.FundacaoModel>? Fundacao { get; set; }

        public DbSet<ObraFacilApp.Models.EletricaModel>? Eletrica { get; set; }
        public DbSet<ComentariosModel> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration(new FundacaoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
