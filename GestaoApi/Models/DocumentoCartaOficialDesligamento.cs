using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    public partial class DocumentoCartaOficialDesligamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Empresa { get; set; }

        public virtual Pessoa idPessoa { get; set; }

        public string? enderecoEmpresa { get; set; }

        public DateOnly dataEmissao { get; set; }

        public DateOnly? dataEfetivaDesligamento { get; set; }
        
        public virtual MotivoDesligamentoEnum idMotivoDesligamento { get; set; }
    }
}