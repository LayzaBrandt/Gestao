using Microsoft.EntityFrameworkCore;
using GestaoApi.Models;
using GestaoApi.Controllers.Interfaces;

public class PessoaRepository : IPessoaRepository
{
    private readonly Contexto _context;
    private readonly ILogger<PessoaRepository> _logger;

    public PessoaRepository(Contexto context, ILogger<PessoaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Pessoa>> SelecionaTodos()
    {
        try
        {
            var pessoas = await _context.Pessoas
                .Include(p => p.IdPessoaXCargos)
                    .ThenInclude(pc => pc.Cargo)
                .ToListAsync();

            return pessoas;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao selecionar todos os cadastros");
            throw;
        }
    }

    public async Task<Pessoa> SelecionarByPK(long id)
    {
        var pessoa = await _context.Pessoas
            .Include(p => p.IdPessoaXCargos)
                .ThenInclude(pc => pc.Cargo)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pessoa != null)
        {
            return pessoa;
        }
        else
        {
            throw new NotFoundException($"Pessoa com ID {id} não encontrada.");
        }
    }

    public void AddPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
    }

public void UpdatePessoa(Pessoa pessoa, List<long> novosCargosIds)
{
        var pessoaExistente = _context.Pessoas
        .Include(p => p.IdPessoaXCargos)
        .FirstOrDefault(p => p.Id == pessoa.Id);
    if (pessoaExistente == null)
    {
        throw new InvalidOperationException("A pessoa não foi encontrada.");
    }

    pessoaExistente.Nome = pessoa.Nome;
    pessoaExistente.Sobrenome = pessoa.Sobrenome;

    var cargosExistentes = _context.PessoaXCargos.Where(x => x.IdPessoa == pessoa.Id).ToList();

    foreach (var cargoExistente in cargosExistentes)
    {
        if (!novosCargosIds.Contains(cargoExistente.IdCargo))
        {
            _context.PessoaXCargos.Remove(cargoExistente);
        }
    }

    foreach (var cargoId in novosCargosIds)
    {
        if (!cargosExistentes.Any(x => x.IdCargo == cargoId))
        {
            var novaAssociacao = new PessoaXCargo
            {
                IdPessoa = pessoa.Id,
                IdCargo = cargoId
            };
            _logger.LogInformation($"Adicionando nova associação: IdPessoa={pessoa.Id}, IdCargo={cargoId}");
            _context.PessoaXCargos.Add(novaAssociacao);


        }
    }

    _context.SaveChanges();
}



    public void RemovePessoa(long id)
    {
        var pessoa = _context.Pessoas
            .Include(p => p.IdPessoaXCargos)
            .FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
        {
            throw new NotFoundException($"Pessoa com ID {id} não encontrada.");
        }

        _context.PessoaXCargos.RemoveRange(pessoa.IdPessoaXCargos);

        _context.Pessoas.Remove(pessoa);
        _context.SaveChanges();
    }
}
