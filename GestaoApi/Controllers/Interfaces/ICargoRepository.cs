using GestaoApi.Models;

namespace GestaoApi.Controllers.Interfaces
{
    public interface ICargoRepository
    {
        void AddCargo(Cargo cargo);

        void UpdateCargo(Cargo cargo);

        void RemoveCargo(int id);

        Task<Cargo> SelecionarByPK(int id);

        Task<IEnumerable<Cargo>> SelecionaTodos();
    }
}
