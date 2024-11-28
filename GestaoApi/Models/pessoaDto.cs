using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi.Models
{
    public partial class PessoaDto
    {
    public Pessoa? Pessoa { get; set; }
    public List<long>? CargosIds { get; set; }

    }
}