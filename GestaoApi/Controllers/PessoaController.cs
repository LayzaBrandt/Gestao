using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas(){
            //return await _pessoaRepository.Pessoa.ToListAsync();

            try
            {
                var pessoas = await _pessoaRepository.SelecionaTodos();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                // Trate a exce��o de forma apropriada, por exemplo, log ou retorne um StatusCode espec�fico.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id){

            var pessoa = await _pessoaRepository.SelecionarByPK(id);
            pessoa.Id = id;
            if (pessoa == null)
            return NotFound();
            
            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult<Pessoa> SalvarPessoa(Pessoa pessoa){
            _pessoaRepository.AddPessoa(pessoa);
            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        } 

        [HttpPut]
        public IActionResult AtualizarPessoa(Pessoa pessoa){
            _pessoaRepository.UpdatePessoa(pessoa);

            return NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirPessoaAsync(int id){
            var pessoa = await _pessoaRepository.SelecionarByPK(id);

            if(pessoa == null){
                return NotFound();
            }

            _pessoaRepository.RemovePessoa(id);

            return NoContent();
        }
    }
}