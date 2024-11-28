using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    public partial class DocumentoCartaOficialDesligamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? Empresa { get; set; }

        public virtual Pessoa? IdPessoa { get; set; }

        public string? enderecoEmpresa { get; set; }

        public DateOnly DataEmissao { get; set; }

        public DateOnly? DataEfetivaDesligamento { get; set; }
        
        public virtual MotivoDesligamentoEnum idMotivoDesligamento { get; set; }
    }
}