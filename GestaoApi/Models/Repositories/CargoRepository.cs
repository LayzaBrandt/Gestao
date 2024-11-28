using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            var cargo = await _context.Cargos
                .ToListAsync();

                _logger.LogInformation("Valor retornado de cargo: {@Cargo}", cargo);
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
        _context.Cargos.Add(cargo);
        _context.SaveChanges();
    }

    public void UpdateCargo(Cargo cargo)
    {
        _context.Entry(cargo).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemoveCargo(long id)
    {
        var cargo = _context.Cargos.Find(id);
        if (cargo != null)
        {
            _context.Cargos.Remove(cargo);
            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Cargo com ID {id} não encontrado");
        }
    }

    public async Task<Cargo> SelecionarByPK(long id)
    {
        var cargo = await _context.Cargos.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (cargo != null)
        {
            return cargo;
        }
        else
        {
            throw new NotFoundException($"Cargo com ID {id} não encontrado");
        }
    }
}
