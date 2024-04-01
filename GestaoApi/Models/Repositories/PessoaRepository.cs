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
                _logger.LogError("O contexto n�o est� inicializado.");
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
        if (pessoa.InformacoesCargo != null)
        {
            _context.Attach(pessoa.InformacoesCargo);
        }
        _context.Pessoa.Add(pessoa);
        _context.SaveChanges();
    }

    public void UpdatePessoa(Pessoa pessoa)
    {
        _context.Entry(pessoa).State = EntityState.Modified;
        if (pessoa.InformacoesCargo != null)
        {
            _context.Attach(pessoa.InformacoesCargo);
        }
        _context.SaveChanges();
    }

    public void RemovePessoa(int id)
    {
        var pessoa = _context.Pessoa.Find(id);

        if (pessoa == null)
        {
            throw new NotFoundException($"Pessoa com ID {id} não encontrada.");
        }

        var documento = _context.Documento.FirstOrDefault(x => x.idPessoa == pessoa);

        if (documento != null)
        {
            throw new NotFoundException($"Não foi possível excluir. Documento vinculado à pessoa a ser excluída.");
        }

        _context.Pessoa.Remove(pessoa);
        _context.SaveChanges();
    }

    public async Task<Pessoa> SelecionarByPK(int id)
    {
        var pessoa = await _context.Pessoa.Include(c => c.InformacoesCargo)
             .Where(x => x.Id == id).FirstOrDefaultAsync();


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
