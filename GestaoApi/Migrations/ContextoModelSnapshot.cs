﻿// <auto-generated />
using System;
using GestaoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoApi.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestaoApi.Models.Cargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateOnly?>("DataEntrada")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DataSaida")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InformacoesSetorId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InformacoesSetorId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("GestaoApi.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InformacoesCargoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InformacoesCargoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("GestaoApi.Models.Setor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("GestaoApi.Models.Cargo", b =>
                {
                    b.HasOne("GestaoApi.Models.Setor", "InformacoesSetor")
                        .WithMany()
                        .HasForeignKey("InformacoesSetorId");

                    b.Navigation("InformacoesSetor");
                });

            modelBuilder.Entity("GestaoApi.Models.Pessoa", b =>
                {
                    b.HasOne("GestaoApi.Models.Cargo", "InformacoesCargo")
                        .WithMany()
                        .HasForeignKey("InformacoesCargoId");

                    b.Navigation("InformacoesCargo");
                });
#pragma warning restore 612, 618
        }
    }
}
