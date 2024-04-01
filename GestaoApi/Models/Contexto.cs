using Microsoft.EntityFrameworkCore;

namespace GestaoApi.Models
{
    public partial class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<DocumentoCartaOficialDesligamento> Documento { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
