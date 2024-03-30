using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    public partial class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? Descricao { get; set; }

        public virtual Setor? InformacoesSetor { get; set; }

        public decimal valor { get; set; }
    }
}