using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoApi.Models
{
    public partial class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? Endereco{ get; set; }

        public DateOnly? DataNascimento { get; set; }

        public virtual Cargo? InformacoesCargo { get; set; }

    }
}