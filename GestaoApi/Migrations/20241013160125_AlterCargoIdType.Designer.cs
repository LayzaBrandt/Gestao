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
    [Migration("20241013160125_AlterCargoIdType")]
    partial class AlterCargoIdType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("IdSetoresEmpresa")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cargo", (string)null);
                });

            modelBuilder.Entity("GestaoApi.Models.DocumentoCartaOficialDesligamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateOnly?>("DataEfetivaDesligamento")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataEmissao")
                        .HasColumnType("date");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("IdPessoaId")
                        .HasColumnType("bigint");

                    b.Property<string>("enderecoEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idMotivoDesligamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoaId");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("GestaoApi.Models.EstadoDoProduto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadoDoProduto");
                });

            modelBuilder.Entity("GestaoApi.Models.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("GestaoApi.Models.PessoaXCargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCargo")
                        .HasColumnType("bigint");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdPessoa");

                    b.ToTable("PessoaXCargo", (string)null);
                });

            modelBuilder.Entity("GestaoApi.Models.PessoaXRecursoEmpresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdRecursoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.HasIndex("IdRecursoId");

                    b.ToTable("PessoaXRecursoEmpresa");
                });

            modelBuilder.Entity("GestaoApi.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("IdEstadoDoProdutoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoDoProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("GestaoApi.Models.RecursoEmpresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRetirada")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdProdutoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdProdutoId");

                    b.ToTable("RecursoEmpresa");
                });

            modelBuilder.Entity("GestaoApi.Models.DocumentoCartaOficialDesligamento", b =>
                {
                    b.HasOne("GestaoApi.Models.Pessoa", "IdPessoa")
                        .WithMany()
                        .HasForeignKey("IdPessoaId");

                    b.Navigation("IdPessoa");
                });

            modelBuilder.Entity("GestaoApi.Models.PessoaXCargo", b =>
                {
                    b.HasOne("GestaoApi.Models.Cargo", "Cargo")
                        .WithMany("IdPessoaXCargos")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoApi.Models.Pessoa", "Pessoa")
                        .WithMany("IdPessoaXCargos")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("GestaoApi.Models.PessoaXRecursoEmpresa", b =>
                {
                    b.HasOne("GestaoApi.Models.Pessoa", "Pessoa")
                        .WithOne("IdPessoaXRecursoEmpresa")
                        .HasForeignKey("GestaoApi.Models.PessoaXRecursoEmpresa", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoApi.Models.RecursoEmpresa", "IdRecurso")
                        .WithMany()
                        .HasForeignKey("IdRecursoId");

                    b.Navigation("IdRecurso");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("GestaoApi.Models.Produto", b =>
                {
                    b.HasOne("GestaoApi.Models.EstadoDoProduto", "IdEstadoDoProduto")
                        .WithMany()
                        .HasForeignKey("IdEstadoDoProdutoId");

                    b.Navigation("IdEstadoDoProduto");
                });

            modelBuilder.Entity("GestaoApi.Models.RecursoEmpresa", b =>
                {
                    b.HasOne("GestaoApi.Models.Produto", "IdProduto")
                        .WithMany()
                        .HasForeignKey("IdProdutoId");

                    b.Navigation("IdProduto");
                });

            modelBuilder.Entity("GestaoApi.Models.Cargo", b =>
                {
                    b.Navigation("IdPessoaXCargos");
                });

            modelBuilder.Entity("GestaoApi.Models.Pessoa", b =>
                {
                    b.Navigation("IdPessoaXCargos");

                    b.Navigation("IdPessoaXRecursoEmpresa");
                });
#pragma warning restore 612, 618
        }
    }
}
