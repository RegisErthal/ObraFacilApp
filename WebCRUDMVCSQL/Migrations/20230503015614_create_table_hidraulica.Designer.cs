﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObraFacilApp.Models;

#nullable disable

namespace ObraFacilApp.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230503015614_create_table_hidraulica")]
    partial class create_table_hidraulica
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObraFacilApp.Models.Alvenaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AlturaBloco")
                        .HasColumnType("float")
                        .HasColumnName("AlturaBloco");

                    b.Property<double>("ComprimentoBlocos")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoBlocos");

                    b.Property<DateTime>("DataConclusaoAlvenaria")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoAlvenaria");

                    b.Property<DateTime>("DataInicioFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioAlvenaria");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<double>("QtdBlocos")
                        .HasColumnType("float")
                        .HasColumnName("QtdBlocos");

                    b.Property<double>("QtdPilares")
                        .HasColumnType("float")
                        .HasColumnName("QtdPilares");

                    b.HasKey("Id");

                    b.ToTable("Alvenaria");
                });

            modelBuilder.Entity("ObraFacilApp.Models.Cobertura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoCobertura")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoCobertura");

                    b.Property<DateTime>("DataInicioCobertura")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioCobertura");

                    b.Property<double>("EspessuraLaje")
                        .HasColumnType("float")
                        .HasColumnName("EspessuraLaje");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<bool>("PossueLaje")
                        .HasColumnType("bit")
                        .HasColumnName("PossueLaje");

                    b.Property<double>("TamanhoCobertura")
                        .HasColumnType("float")
                        .HasColumnName("TamanhoCobertura");

                    b.HasKey("Id");

                    b.ToTable("Cobertura");
                });

            modelBuilder.Entity("ObraFacilApp.Models.Eletrica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoEletrica");

                    b.Property<DateTime>("DataInicioEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioEletrica");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<bool>("LigacaoMonofasica")
                        .HasColumnType("bit")
                        .HasColumnName("LigacaoMonofasica");

                    b.Property<bool>("LigacaoTrifasica")
                        .HasColumnType("bit")
                        .HasColumnName("LigacaoTrifasica");

                    b.Property<double>("QtdDisjuntores")
                        .HasColumnType("float")
                        .HasColumnName("QtdDisjuntores");

                    b.Property<double>("QtdLampadas")
                        .HasColumnType("float")
                        .HasColumnName("QtdLampadas");

                    b.Property<double>("QtdTomadas")
                        .HasColumnType("float")
                        .HasColumnName("QtdTomadas");

                    b.HasKey("Id");

                    b.ToTable("Eletrica");
                });

            modelBuilder.Entity("ObraFacilApp.Models.Fundacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AlturaAlicerce")
                        .HasColumnType("float")
                        .HasColumnName("AlturaAlicerce");

                    b.Property<double>("AlturaPedra")
                        .HasColumnType("float")
                        .HasColumnName("AlturaPedra");

                    b.Property<double>("AlturaVigaBaldrame")
                        .HasColumnType("float")
                        .HasColumnName("AlturaVigaBaldrame");

                    b.Property<double>("ComprimentoAlicerce")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoAlicerce");

                    b.Property<double>("ComprimentoPedra")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoPedra");

                    b.Property<double>("ComprimentoVigaBaldrame")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoVigaBaldrame");

                    b.Property<DateTime>("DataConclusaoFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoFundacao");

                    b.Property<DateTime>("DataInicioFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioFundacao");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<double>("LarguraVigaBaldrame")
                        .HasColumnType("float")
                        .HasColumnName("LarguraVigaBaldrame");

                    b.Property<double>("MetragemCubicaCimentoVigaBaldrama")
                        .HasColumnType("float")
                        .HasColumnName("MetragemCubicaCimentoVigaBaldrama");

                    b.Property<double>("QtdBlocosAlicerce")
                        .HasColumnType("float")
                        .HasColumnName("QtdBlocosAlicerce");

                    b.Property<double>("QtdMicro")
                        .HasColumnType("float")
                        .HasColumnName("QtdMicro");

                    b.HasKey("Id");

                    b.ToTable("Fundacao");
                });

            modelBuilder.Entity("ObraFacilApp.Models.Hidraulica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoEletrica");

                    b.Property<DateTime>("DataInicioEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioEletrica");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<double>("QtdRalos")
                        .HasColumnType("float")
                        .HasColumnName("QtdRalos");

                    b.Property<double>("QtdTorneiras")
                        .HasColumnType("float")
                        .HasColumnName("QtdTorneiras");

                    b.HasKey("Id");

                    b.ToTable("Hidraulica");
                });

            modelBuilder.Entity("ObraFacilApp.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Senha");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserName");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("isAdmin");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ObraFacilApp.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustoMetro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CustoMetro");

                    b.Property<DateTime>("DataConclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusao");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicio");

                    b.Property<string>("EmailResponsavel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailResponsavel");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeProjeto");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Responsavel");

                    b.HasKey("Id");

                    b.ToTable("Projeto");
                });
#pragma warning restore 612, 618
        }
    }
}
