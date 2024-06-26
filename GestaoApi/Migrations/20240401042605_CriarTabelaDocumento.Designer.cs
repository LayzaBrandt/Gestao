﻿// <auto-generated />
using System;
using GestaoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoApi.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240401042605_CriarTabelaDocumento")]
    partial class CriarTabelaDocumento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestaoApi.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DataEntrada")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DataSaida")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InformacoesSetor")
                        .HasColumnType("int");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("GestaoApi.Models.DocumentoCartaOficialDesligamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("dataEfetivaDesligamento")
                        .HasColumnType("date");

                    b.Property<DateOnly>("dataEmissao")
                        .HasColumnType("date");

                    b.Property<string>("enderecoEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idMotivoDesligamento")
                        .HasColumnType("int");

                    b.Property<int?>("idPessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idPessoaId");

                    b.ToTable("Documento");
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

                    b.Property<int?>("InformacoesCargoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InformacoesCargoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("GestaoApi.Models.DocumentoCartaOficialDesligamento", b =>
                {
                    b.HasOne("GestaoApi.Models.Pessoa", "idPessoa")
                        .WithMany()
                        .HasForeignKey("idPessoaId");

                    b.Navigation("idPessoa");
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
