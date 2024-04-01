using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.EntityFrameworkCore;

public class DocumentoCartaOficialDesligamentoRepository : IDocumentoCartaOficialDesligamentoRepository
{
    private readonly Contexto _context;
    private readonly ILogger<DocumentoCartaOficialDesligamentoRepository> _logger;


    public DocumentoCartaOficialDesligamentoRepository(Contexto context, ILogger<DocumentoCartaOficialDesligamentoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IEnumerable<DocumentoCartaOficialDesligamento>> SelecionaTodos()
    {
        try
        {
            if (_context == null)
            {
                _logger.LogError("O contexto não esta inicializado.");
                return Enumerable.Empty<DocumentoCartaOficialDesligamento>();
            }

            var documento = await _context.Documento
                .Include(c => c.idPessoa)
                .ToListAsync();

            return documento;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao selecionar todos os cadastros de documentos");
            throw;
        }
    }
    public void AddDocumento(DocumentoCartaOficialDesligamento documento)
    {
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Documento ON");
        if (documento.idPessoa != null)
        {
            _context.Attach(documento.idPessoa);
        }
        _context.Documento.Add(documento);
        _context.SaveChanges();
    }

    public void UpdateDocumento(DocumentoCartaOficialDesligamento documento)
    {
        _context.Entry(documento).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemoveDocumento(int id)
    {
        var documento = _context.Documento.Find(id);
        if (documento != null)
        {
            _context.Documento.Remove(documento);
            _context.SaveChanges();
        }
    }

    public async Task<DocumentoCartaOficialDesligamento> SelecionarByPK(int id)
    {
        var documento = await _context.Documento.Include(c => c.idPessoa)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        if (documento != null)
        {
            return documento;
        }
        else
        {
            throw new NotFoundException($"Documento com ID {id} não encontrado");
        }
    }

}
