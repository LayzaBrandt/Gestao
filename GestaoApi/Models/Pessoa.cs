using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoApi.Models
{
    [Table("Pessoa")]
    public partial class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public ICollection<PessoaXCargo> IdPessoaXCargos { get; set; } = new List<PessoaXCargo>();

        public PessoaXRecursoEmpresa? IdPessoaXRecursoEmpresa { get; set; }

    }
}