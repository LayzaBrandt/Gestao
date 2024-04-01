using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.EntityFrameworkCore;

public class CargoRepository : ICargoRepository
{
    private readonly Contexto _context;
    private readonly ILogger<CargoRepository> _logger;


    public CargoRepository(Contexto context, ILogger<CargoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IEnumerable<Cargo>> SelecionaTodos()
    {
        try
        {
            if (_context == null)
            {
                _logger.LogError("O contexto n�o est� inicializado.");
                return Enumerable.Empty<Cargo>();
            }
            var cargo = await _context.Cargo
                .ToListAsync();
            return cargo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao selecionar todos os cadastros de cargos");
            throw;
        }
    }
    public void AddCargo(Cargo cargo)
    {
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Cargo ON");
        _context.Cargo.Add(cargo);
        _context.SaveChanges();
    }

    public void UpdateCargo(Cargo cargo)
    {
        _context.Entry(cargo).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemoveCargo(int id)
    {
        var cargo = _context.Cargo.Find(id);
        if (cargo != null)
        {
            _context.Cargo.Remove(cargo);
            _context.SaveChanges();
        }
    }

    public async Task<Cargo> SelecionarByPK(int id)
    {
        var cargo = await _context.Cargo.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (cargo != null)
        {
            return cargo;
        }
        else
        {
            throw new NotFoundException($"Cargo com ID {id} n�o encontrado");
        }
    }

}
