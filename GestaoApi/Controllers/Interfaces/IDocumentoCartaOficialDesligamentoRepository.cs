using GestaoApi.Models;

namespace GestaoApi.Controllers.Interfaces
{
    public interface IDocumentoCartaOficialDesligamentoRepository
    {
        void AddDocumento(DocumentoCartaOficialDesligamento documento);

        void UpdateDocumento(DocumentoCartaOficialDesligamento documento);

        void RemoveDocumento(long id);

        Task<DocumentoCartaOficialDesligamento> SelecionarByPK(long id);

        Task<IEnumerable<DocumentoCartaOficialDesligamento>> SelecionaTodos();
    }
}
