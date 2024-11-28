using GestaoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoApi.Controllers.Interfaces
{
    public interface IPessoaRepository
    {
        void AddPessoa(Pessoa pessoa);

        void UpdatePessoa(Pessoa pessoa, List<long> novosCargosIds);

        void RemovePessoa(long id);

        Task<Pessoa> SelecionarByPK(long id);

        Task<IEnumerable<Pessoa>> SelecionaTodos();
    }
}
