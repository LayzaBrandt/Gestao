using Microsoft.EntityFrameworkCore;
using GestaoApi.Models;
using GestaoApi.Controllers.Interfaces;
using System.Linq;

public class PessoaRepository : IPessoaRepository
{
    private readonly Contexto _context;
    private readonly ILogger<PessoaRepository> _logger;

    public PessoaRepository(Contexto context, ILogger<PessoaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<PessoaDto>> SelecionaTodos()
    {
        try
        {
            var pessoas = await _context.Pessoas
                .Include(p => p.IdPessoaXCargos)
                    .ThenInclude(pc => pc.Cargo)
                .Select(p => new PessoaDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Sobrenome = p.Sobrenome,
                    IdPessoaXCargos = p.IdPessoaXCargos.Select(pc => new PessoaXCargoDto
                    {
                        Id = pc.Id,
                        IdCargo = pc.IdCargo,
                        DescricaoCargo = pc.Cargo != null ? pc.Cargo.Descricao : "Descrição não disponível",
                        Cargo = pc.Cargo
                    }).ToList()
                })
                .ToListAsync();

            return pessoas;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao selecionar todos os cadastros");
            throw;
        }
    }

    public async Task<PessoaDto> SelecionarByPK(long id)
    {
        var pessoa = await _context.Pessoas
            .Include(p => p.IdPessoaXCargos)
                .ThenInclude(pc => pc.Cargo)
            .Where(p => p.Id == id)
            .Select(p => new PessoaDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Sobrenome = p.Sobrenome,
                IdPessoaXCargos = p.IdPessoaXCargos.Select(pc => new PessoaXCargoDto
                {
                    Id = pc.Id,
                    IdCargo = pc.IdCargo,
                    DescricaoCargo = pc.Cargo != null ? pc.Cargo.Descricao : "Descrição não disponível"
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (pessoa != null)
        {
            return pessoa;
        }
        
        throw new NotFoundException($"Pessoa com ID {id} não encontrada.");
    }

    public void AddPessoa(PessoaDto pessoaDto, List<long> cargosIds)
    {
        var pessoa = new Pessoa
        {
            Nome = pessoaDto.Nome,
            Sobrenome = pessoaDto.Sobrenome
        };
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        if (cargosIds != null && cargosIds.Count > 0)
        {
            foreach (var cargoId in cargosIds)
            {
                var novaAssociacao = new PessoaXCargo
                {
                    IdPessoa = pessoa.Id,
                    IdCargo = cargoId
                };

                _logger.LogInformation($"Adicionando nova associação: IdPessoa={pessoa.Id}, IdCargo={cargoId}");
                _context.PessoaXCargos.Add(novaAssociacao);
            }

            _context.SaveChanges();
        }
    }

    public void UpdatePessoa(PessoaDto pessoaDto, List<long> novosCargosIds)
    {
        var pessoaExistente = _context.Pessoas
            .Include(p => p.IdPessoaXCargos)
            .FirstOrDefault(p => p.Id == pessoaDto.Id);

        if (pessoaExistente == null)
        {
            throw new InvalidOperationException($"A pessoa não foi encontrada.{pessoaDto.Id}");
        }

        pessoaExistente.Nome = pessoaDto.Nome;
        pessoaExistente.Sobrenome = pessoaDto.Sobrenome;

        var cargosExistentes = _context.PessoaXCargos.Where(x => x.IdPessoa == pessoaDto.Id).ToList();

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
                    IdPessoa = pessoaDto.Id,
                    IdCargo = cargoId
                };
                _logger.LogInformation($"Adicionando nova associação: IdPessoa={pessoaDto.Id}, IdCargo={cargoId}");
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
