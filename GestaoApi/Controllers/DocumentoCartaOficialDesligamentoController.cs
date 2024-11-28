using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoCartaOficialDesligamentoController : ControllerBase
    {
        private readonly IDocumentoCartaOficialDesligamentoRepository _documentoCartaOficialDesligamentoRepository;
        public DocumentoCartaOficialDesligamentoController(IDocumentoCartaOficialDesligamentoRepository documentoCartaOficialDesligamentoRepository)
        {
            _documentoCartaOficialDesligamentoRepository = documentoCartaOficialDesligamentoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoCartaOficialDesligamento>>> GetDocumentos(){

            try
            {
                var documentos = await _documentoCartaOficialDesligamentoRepository.SelecionaTodos();
                return Ok(documentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoCartaOficialDesligamento>> GetDocumento(long id){

            var documentos = await _documentoCartaOficialDesligamentoRepository.SelecionarByPK(id);
            documentos.Id = id;
            if (documentos == null)
            return NotFound();
            
            return Ok(documentos);
        }

        [HttpPost]
        public ActionResult<DocumentoCartaOficialDesligamento> SalvarDocumento(DocumentoCartaOficialDesligamento documento){
            _documentoCartaOficialDesligamentoRepository.AddDocumento(documento);
            return CreatedAtAction("GetDocumento", new { id = documento.Id }, documento);
        } 

        [HttpPut]
        public IActionResult AtualizarDocumento(DocumentoCartaOficialDesligamento documento){
            _documentoCartaOficialDesligamentoRepository.UpdateDocumento(documento);

            return NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirDocumentoAsync(long id){
            var documento = await _documentoCartaOficialDesligamentoRepository.SelecionarByPK(id);

            if(documento == null){
                return NotFound();
            }

            _documentoCartaOficialDesligamentoRepository.RemoveDocumento(id);

            return NoContent();
        }
    }
}