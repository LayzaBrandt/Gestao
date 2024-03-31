using GestaoApi.Controllers.Interfaces;
using GestaoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepository _cargoRepository;
        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos(){

            try
            {
                var cargos = await _cargoRepository.SelecionaTodos();
                return Ok(cargos);
            }
            catch (Exception ex)
            {
                // Trate a exce��o de forma apropriada, por exemplo, log ou retorne um StatusCode espec�fico.
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id){

            var cargos = await _cargoRepository.SelecionarByPK(id);
            cargos.Id = id;
            if (cargos == null)
            return NotFound();
            
            return Ok(cargos);
        }

        [HttpPost]
        public ActionResult<Cargo> SalvarCargo(Cargo cargo){
            _cargoRepository.AddCargo(cargo);
            return CreatedAtAction("GetCargo", new { id = cargo.Id }, cargo);
        } 

        [HttpPut]
        public IActionResult AtualizarCargo(Cargo cargo){
            _cargoRepository.UpdateCargo(cargo);

            return NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCargoAsync(int id){
            var cargo = await _cargoRepository.SelecionarByPK(id);

            if(cargo == null){
                return NotFound();
            }

            _cargoRepository.RemoveCargo(id);

            return NoContent();
        }
    }
}