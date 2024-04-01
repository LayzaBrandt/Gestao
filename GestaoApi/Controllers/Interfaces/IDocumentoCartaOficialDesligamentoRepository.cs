using GestaoApi.Models;

namespace GestaoApi.Controllers.Interfaces
{
    public interface IDocumentoCartaOficialDesligamentoRepository
    {
        void AddDocumento(DocumentoCartaOficialDesligamento documento);

        void UpdateDocumento(DocumentoCartaOficialDesligamento documento);

        void RemoveDocumento(int id);

        Task<DocumentoCartaOficialDesligamento> SelecionarByPK(int id);

        Task<IEnumerable<DocumentoCartaOficialDesligamento>> SelecionaTodos();
    }
}
