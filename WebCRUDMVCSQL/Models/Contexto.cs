﻿using Microsoft.EntityFrameworkCore;

namespace ObraFacilApp.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<ObraFacilApp.Models.Projeto>? Projeto_1 { get; set; }

    }
}
