using GestaoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoApi.Controllers.Interfaces
{
    public interface IPessoaRepository
    {
        void AddPessoa(PessoaDto pessoa, List<long> cargosIds);

        void UpdatePessoa(PessoaDto pessoa, List<long> novosCargosIds);

        void RemovePessoa(long id);

        Task<PessoaDto> SelecionarByPK(long id);

        Task<IEnumerable<PessoaDto>> SelecionaTodos();
    }
}
