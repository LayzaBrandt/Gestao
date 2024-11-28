using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    public partial class PessoaDto
    {
    public long Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public PessoaDto? Pessoa { get; set; }
    public List<PessoaXCargoDto> IdPessoaXCargos { get; set; } = new List<PessoaXCargoDto>();
    public List<long>? CargosIds { get; set; }

    }
}