using Microsoft.EntityFrameworkCore;

namespace GestaoApi.Models
{
    public partial class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pessoa>(entity =>
            //{
            //    entity.HasKey(e => e.Id).HasName("Id");
            //    entity.ToTable("Pessoa");
            //    entity.Property(e => e.Sobrenome).HasMaxLength(130).IsUnicode(false).HasColumnName("Sobrenome");
            //    entity.Property(e => e.DataNascimento).IsUnicode(false).HasColumnName("DataNascimento");
            //    entity.Property(e => e.Nome).HasMaxLength(130).IsUnicode(false).HasColumnName("Nome");
            //    entity.HasOne(p => p.InformacoesCargo)
            //          .WithMany()
            //          .HasForeignKey(p => p.IdInformacoesCargo);
            //});

           /* modelBuilder.Entity<SetorEnum>(entity =>
            {
                entity.ToTable("Setor"); // Define o nome da tabela
                entity.HasKey(e => e.Id).HasName("Id"); // Define a chave primária
                entity.Property(e => e.Descricao).HasMaxLength(255).IsUnicode(false); // Define as propriedades da coluna Descrição
            });*/

            //modelBuilder.Entity<Cargo>(entity =>
            //{
            //    entity.HasKey(e => e.Id).HasName("Id");
            //    entity.ToTable("Cargo");
            //    entity.Property(e => e.Descricao).HasMaxLength(130).IsUnicode(false);
            //    entity.HasOne(p => p.InformacoesSetor)
            //         .WithMany()
            //         .HasForeignKey(p => p.IdInformacoesSetor);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
