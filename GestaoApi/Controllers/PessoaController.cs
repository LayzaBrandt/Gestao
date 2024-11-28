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
        private readonly IPessoaXCargoRepository _pessoaXCargoRepository;
        public PessoaController(IPessoaRepository pessoaRepository,IPessoaXCargoRepository pessoaXCargoRepository)
        {
            _pessoaRepository = pessoaRepository;
             _pessoaXCargoRepository = pessoaXCargoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetPessoas(){

            try
            {
                var pessoas = await _pessoaRepository.SelecionaTodos();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(long id){

     Console.WriteLine("pessoa: " + string.Join(", ", id));
            var pessoa = await _pessoaRepository.SelecionarByPK(id);
            pessoa.Id = id;
            if (pessoa == null)
            return NotFound();
            
            return Ok(pessoa);
        }

        [HttpPost]
public ActionResult<PessoaDto> SalvarPessoa([FromBody] PessoaDto body)
{
    if (body?.Id == null)
    {
        return BadRequest("Dados da pessoa não podem ser nulos.");
    }

    if (body.CargosIds != null && body.CargosIds.Any())
    {
        Console.WriteLine("CARGOS: " + string.Join(", ", body.CargosIds));
        if (body.Pessoa != null)
        {
        _pessoaRepository.AddPessoa(body.Pessoa, body.CargosIds);
        }
    }
    else
    {
        return BadRequest("Dados de cargo da pessoa selecionada não podem ser nulos.");
    }

    return CreatedAtAction("GetPessoa", new { id = body.Id }, body);
}

    [HttpPut]
    public IActionResult AtualizarPessoa([FromBody] PessoaDto body )
    {

    if (body == null)
    {
        return BadRequest("Dados da pessoa não podem ser nulos.");
    }
    if (body.CargosIds != null && body.CargosIds.Any())
        {
    Console.WriteLine("CARGOS: " + string.Join(", ", body.CargosIds));
    if (body.Pessoa != null)
        {
    _pessoaRepository.UpdatePessoa(body.Pessoa, body.CargosIds);
        }
    }
    else
    {
        Console.WriteLine("A lista está vazia ou é nula.");
    }

    return NoContent();
    }


        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirPessoaAsync(long id){
            var pessoa = await _pessoaRepository.SelecionarByPK(id);
            
            if(pessoa == null){
                return NotFound();
            }

            _pessoaRepository.RemovePessoa(id);

            return NoContent();
        }
    }
}