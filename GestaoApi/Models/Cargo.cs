using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    public partial class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public SetoresEmpresaEnum InformacoesSetor { get; set; }

        public decimal valor { get; set; }

        public DateOnly? DataEntrada { get; set; }
        
        public DateOnly? DataSaida { get; set; }
    }
}