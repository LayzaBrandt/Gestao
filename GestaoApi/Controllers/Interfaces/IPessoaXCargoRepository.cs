using GestaoApi.Models;

namespace GestaoApi.Controllers.Interfaces
{
    public interface IPessoaXCargoRepository
    {
          void AddPessoaXCargo(PessoaXCargo pessoaXCargo);
          void SaveChanges();

          List<PessoaXCargo> GetCargosByPessoaId(int pessoaId);

          void RemovePessoaXCargos (IEnumerable<PessoaXCargo> pessoaXCargos);

        IEnumerable<PessoaXCargo> GetByPessoaId(long pessoaId);
    }
}