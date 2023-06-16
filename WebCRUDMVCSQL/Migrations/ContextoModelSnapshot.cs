﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObraFacilApp.Models;

#nullable disable

namespace ObraFacilApp.Migrations
{
    [DbContext(typeof(ContextoModel))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObraFacilApp.Models.AlvenariaModel", b =>
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

                    b.Property<bool>("DataConclusaoAlvenariaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioAlvenaria")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioAlvenaria");

                    b.Property<bool>("DataInicioAlvenariaOk")
                        .HasColumnType("bit");

                    b.Property<double>("MetrosDeParede")
                        .HasColumnType("float")
                        .HasColumnName("MetrosDeParede");

                    b.Property<bool>("MetrosDeParedeOK")
                        .HasColumnType("bit");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int")
                        .HasColumnName("ProjetoId");

                    b.Property<double>("QtdBlocos")
                        .HasColumnType("float")
                        .HasColumnName("QtdBlocos");

                    b.Property<bool>("QtdBlocosOk")
                        .HasColumnType("bit");

                    b.Property<double>("QtdPilares")
                        .HasColumnType("float")
                        .HasColumnName("QtdPilares");

                    b.Property<bool>("QtdPilaresOk")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Alvenaria");
                });

            modelBuilder.Entity("ObraFacilApp.Models.CoberturaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoCobertura")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoCobertura");

                    b.Property<bool>("DataConclusaoCoberturaOK")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioCobertura")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioCobertura");

                    b.Property<bool>("DataInicioCoberturaOK")
                        .HasColumnType("bit");

                    b.Property<double>("EspessuraLaje")
                        .HasColumnType("float")
                        .HasColumnName("EspessuraLaje");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<double>("MetragemCubicaLage")
                        .HasColumnType("float")
                        .HasColumnName("MetragemCubicaLAge");

                    b.Property<bool>("MetragemCubicaLageOk")
                        .HasColumnType("bit");

                    b.Property<bool>("PossueLaje")
                        .HasColumnType("bit")
                        .HasColumnName("PossueLaje");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<double>("TamanhoCobertura")
                        .HasColumnType("float")
                        .HasColumnName("TamanhoCobertura");

                    b.Property<bool>("TamanhoCoberturaOK")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Cobertura");
                });

            modelBuilder.Entity("ObraFacilApp.Models.CronogramaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoAlvenaria")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoAlvenaria");

                    b.Property<bool>("DataConclusaoAlvenariaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataConclusaoCobertura")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoCobertura");

                    b.Property<DateTime>("DataConclusaoEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoEletrica");

                    b.Property<bool>("DataConclusaoEletricaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataConclusaoFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioAlvenaria");

                    b.Property<bool>("DataConclusaoFundacaoOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataConclusaoHidraulica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoHidraulica");

                    b.Property<bool>("DataConclusaoHidraulicaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioCobertura")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioCobertura");

                    b.Property<bool>("DataInicioCoberturaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioEletrica");

                    b.Property<bool>("DataInicioEletricaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoFundacao");

                    b.Property<bool>("DataInicioFundacaoOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioHidraulica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioHidraulica ");

                    b.Property<bool>("DataInicioHidraulicaOk")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cronograma");
                });

            modelBuilder.Entity("ObraFacilApp.Models.EletricaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoEletrica");

                    b.Property<bool>("DataConclusaoEletricaOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioEletrica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioEletrica");

                    b.Property<bool>("DataInicioEletricaOk")
                        .HasColumnType("bit");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int")
                        .HasColumnName("ProjetoId");

                    b.Property<bool>("LigacaoMonofasica")
                        .HasColumnType("bit")
                        .HasColumnName("LigacaoMonofasica");

                    b.Property<bool>("LigacaoMonofasicaOk")
                        .HasColumnType("bit");

                    b.Property<bool>("LigacaoTrifasica")
                        .HasColumnType("bit")
                        .HasColumnName("LigacaoTrifasica");

                    b.Property<bool>("LigacaoTrifasicaOk")
                        .HasColumnType("bit");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<double>("QtdDisjuntores")
                        .HasColumnType("float")
                        .HasColumnName("QtdDisjuntores");

                    b.Property<bool>("QtdDisjuntoresOk")
                        .HasColumnType("bit");

                    b.Property<double>("QtdLampadas")
                        .HasColumnType("float")
                        .HasColumnName("QtdLampadas");

                    b.Property<bool>("QtdLampadasOk")
                        .HasColumnType("bit");

                    b.Property<double>("QtdTomadas")
                        .HasColumnType("float")
                        .HasColumnName("QtdTomadas");

                    b.Property<bool>("QtdTomadasOk")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Eletrica", t =>
                        {
                            t.Property("ProjetoId")
                                .HasColumnName("ProjetoId1");
                        });
                });

            modelBuilder.Entity("ObraFacilApp.Models.FundacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AlturaAlicerce")
                        .HasColumnType("float")
                        .HasColumnName("AlturaAlicerce");

                    b.Property<bool>("AlturaAlicerceOK")
                        .HasColumnType("bit");

                    b.Property<double>("AlturaPedra")
                        .HasColumnType("float")
                        .HasColumnName("AlturaPedra");

                    b.Property<bool>("AlturaPedraOK")
                        .HasColumnType("bit");

                    b.Property<double>("AlturaVigaBaldrame")
                        .HasColumnType("float")
                        .HasColumnName("AlturaVigaBaldrame");

                    b.Property<bool>("AlturaVigaBaldrameOK")
                        .HasColumnType("bit");

                    b.Property<double>("ComprimentoAlicerce")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoAlicerce");

                    b.Property<bool>("ComprimentoAlicerceOK")
                        .HasColumnType("bit");

                    b.Property<double>("ComprimentoPedra")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoPedra");

                    b.Property<bool>("ComprimentoPedraOK")
                        .HasColumnType("bit");

                    b.Property<double>("ComprimentoVigaBaldrame")
                        .HasColumnType("float")
                        .HasColumnName("ComprimentoVigaBaldrame");

                    b.Property<bool>("ComprimentoVigaBaldrameOK")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataConclusaoFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoFundacao");

                    b.Property<bool>("DataConclusaoFundacaoOK")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioFundacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioFundacao");

                    b.Property<bool>("DataInicioFundacaoOK")
                        .HasColumnType("bit");

                    b.Property<double>("LarguraVigaBaldrame")
                        .HasColumnType("float")
                        .HasColumnName("LarguraVigaBaldrame");

                    b.Property<bool>("LarguraVigaBaldrameOK")
                        .HasColumnType("bit");

                    b.Property<double>("MetragemCubicaCimentoVigaBaldrama")
                        .HasColumnType("float")
                        .HasColumnName("MetragemCubicaCimentoVigaBaldrama");

                    b.Property<bool>("MetragemCubicaCimentoVigaBaldramaOK")
                        .HasColumnType("bit");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int")
                        .HasColumnName("ProjetoId");

                    b.Property<double>("QtdBlocosAlicerce")
                        .HasColumnType("float")
                        .HasColumnName("QtdBlocosAlicerce");

                    b.Property<bool>("QtdBlocosAlicerceOK")
                        .HasColumnType("bit");

                    b.Property<double>("QtdMicro")
                        .HasColumnType("float")
                        .HasColumnName("QtdMicro");

                    b.Property<bool>("QtdMicroOK")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Fundacao");
                });

            modelBuilder.Entity("ObraFacilApp.Models.HidraulicaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConclusaoHidraulica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusaoHidraulica");

                    b.Property<bool>("DataConclusaoHidraulicaOK")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataInicioHidraulica")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicioHidraulica ");

                    b.Property<bool>("DataInicioHidraulicaOK")
                        .HasColumnType("bit");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int")
                        .HasColumnName("ProjetoId");

                    b.Property<double>("QtdRalos")
                        .HasColumnType("float")
                        .HasColumnName("QtdRalos");

                    b.Property<bool>("QtdRalosOK")
                        .HasColumnType("bit");

                    b.Property<double>("QtdTorneiras")
                        .HasColumnType("float")
                        .HasColumnName("QtdTorneiras");

                    b.Property<bool>("QtdTorneirasOK")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Hidraulica");
                });

            modelBuilder.Entity("ObraFacilApp.Models.LoginModel", b =>
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

            modelBuilder.Entity("ObraFacilApp.Models.ProjetoModel", b =>
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

            modelBuilder.Entity("ObraFacilApp.Models.AlvenariaModel", b =>
                {
                    b.HasOne("ObraFacilApp.Models.ProjetoModel", "Projeto")
                        .WithMany("Alvenarias")
                        .HasForeignKey("ProjetoId");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ObraFacilApp.Models.CoberturaModel", b =>
                {
                    b.HasOne("ObraFacilApp.Models.ProjetoModel", "Projeto")
                        .WithMany("Coberturas")
                        .HasForeignKey("ProjetoId");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ObraFacilApp.Models.EletricaModel", b =>
                {
                    b.HasOne("ObraFacilApp.Models.ProjetoModel", "Projeto")
                        .WithMany("Eletricas")
                        .HasForeignKey("ProjetoId");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ObraFacilApp.Models.FundacaoModel", b =>
                {
                    b.HasOne("ObraFacilApp.Models.ProjetoModel", "Projeto")
                        .WithMany("Fundacaos")
                        .HasForeignKey("ProjetoId");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ObraFacilApp.Models.HidraulicaModel", b =>
                {
                    b.HasOne("ObraFacilApp.Models.ProjetoModel", "Projeto")
                        .WithMany("Hidraulicas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("ObraFacilApp.Models.ProjetoModel", b =>
                {
                    b.Navigation("Alvenarias");

                    b.Navigation("Coberturas");

                    b.Navigation("Eletricas");

                    b.Navigation("Fundacaos");

                    b.Navigation("Hidraulicas");
                });
#pragma warning restore 612, 618
        }
    }
}
