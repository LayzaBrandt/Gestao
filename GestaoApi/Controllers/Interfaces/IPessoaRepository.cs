using GestaoApi.Models;

namespace GestaoApi.Controllers.Interfaces
{
    public interface IPessoaRepository
    {
        void AddPessoa(Pessoa pessoa);

        void UpdatePessoa(Pessoa pessoa);

        void RemovePessoa(int id);

        Task<Pessoa> SelecionarByPK(int id);

        Task<IEnumerable<Pessoa>> SelecionaTodos();
    }
}
