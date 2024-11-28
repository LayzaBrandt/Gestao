using Microsoft.EntityFrameworkCore;
using GestaoApi.Models;
using GestaoApi.Controllers.Interfaces;

namespace GestaoApi.Models.Repositories
{
    public class PessoaXCargoRepository : IPessoaXCargoRepository
    {
        private readonly Contexto _context;

         private readonly ILogger<PessoaRepository> _logger;

        public PessoaXCargoRepository (Contexto context, ILogger<PessoaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }


    public void AddPessoaXCargo(PessoaXCargo pessoaXCargo)
    {
        _context.PessoaXCargos.Add(pessoaXCargo);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public List<PessoaXCargo> GetCargosByPessoaId(int pessoaId)
    {
        return _context.PessoaXCargos
                       .Include(px => px.Cargo) 
                       .Where(px => px.IdPessoa == pessoaId)
                       .ToList();
    }
    public IEnumerable<PessoaXCargo> GetByPessoaId(long pessoaId)
    {
        return _context.PessoaXCargos.Where(pxc => pxc.IdPessoa == pessoaId).ToList();
    }

    public void RemovePessoaXCargos(IEnumerable<PessoaXCargo> pessoaXCargos)
    {
    _context.PessoaXCargos.RemoveRange(pessoaXCargos);
    _context.SaveChanges();
    }

    }
}