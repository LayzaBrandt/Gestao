using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    [Table("Cargo")]
    public partial class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? Descricao { get; set; }

        public SetoresEmpresaEnum IdSetoresEmpresa { get; set; }

        public decimal Valor { get; set; }

        public DateOnly? DataEntrada { get; set; }
        
        public DateOnly? DataSaida { get; set; }

        public ICollection<PessoaXCargo> IdPessoaXCargos { get; set; } = new List<PessoaXCargo>();
    }
}