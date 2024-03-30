using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.EntityFrameworkCore;

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
            if (_context == null)
            {
                _logger.LogError("O contexto não está inicializado.");
                return Enumerable.Empty<Pessoa>();
            }

            var pessoa = await _context.Pessoa
                .Include(c => c.InformacoesCargo)
                .ToListAsync();

            return pessoa;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao selecionar todos os cadastros");
            throw;
        }
    }
    public void AddPessoa(Pessoa pessoa)
    {
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Pessoa ON");
        _context.Pessoa.Add(pessoa);
        _context.SaveChanges();
    }

    public void UpdatePessoa(Pessoa pessoa)
    {
        _context.Entry(pessoa).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemovePessoa(int id)
    {
        var pessoa = _context.Pessoa.Find(id);
        if (pessoa != null)
        {
            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
        }
    }

    public async Task<Pessoa> SelecionarByPK(int id)
    {
        var pessoa = await _context.Pessoa.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (pessoa != null)
        {
            return pessoa;
        }
        else
        {
            throw new NotFoundException($"Pessoa com ID {id} não encontrado");
        }
    }

}
