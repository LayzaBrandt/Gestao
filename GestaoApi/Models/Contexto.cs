using Microsoft.EntityFrameworkCore;

namespace GestaoApi.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<PessoaXCargo> PessoaXCargos { get; set; }
        public DbSet<DocumentoCartaOficialDesligamento> Documento { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PessoaXCargo>()
        .HasKey(pc => pc.Id); 

            modelBuilder.Entity<PessoaXCargo>()
                .Property(pc => pc.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PessoaXCargo>()
                .HasOne(pc => pc.Pessoa)
                .WithMany(p => p.IdPessoaXCargos)
                .HasForeignKey(pc => pc.IdPessoa)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<PessoaXCargo>()
                .HasOne(pc => pc.Cargo)
                .WithMany(c => c.IdPessoaXCargos)
                .HasForeignKey(pc => pc.IdCargo)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.IdPessoaXRecursoEmpresa)  
                .WithOne(pre => pre.Pessoa)               
                .HasForeignKey<PessoaXRecursoEmpresa>(pre => pre.IdPessoa)
                .OnDelete(DeleteBehavior.Cascade);   


        modelBuilder.Entity<PessoaXCargo>()
            .HasKey(pc => new { pc.IdPessoa, pc.IdCargo });

            modelBuilder.Entity<Pessoa>()
                .ToTable("Pessoa");

            modelBuilder.Entity<PessoaXCargo>()
                .ToTable("PessoaXCargo");

            modelBuilder.Entity<Cargo>()
                .ToTable("Cargo");

           modelBuilder.Entity<Cargo>()
                .Property(c => c.Valor)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
