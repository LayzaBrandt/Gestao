using GestaoApi.Models;

namespace GestaoApi.Controllers.Interfaces
{
    public interface ICargoRepository
    {
        void AddCargo(Cargo cargos);

        void UpdateCargo(Cargo cargos);

        void RemoveCargo(long id);

        Task<Cargo> SelecionarByPK(long id);

        Task<IEnumerable<Cargo>> SelecionaTodos();
    }
}
