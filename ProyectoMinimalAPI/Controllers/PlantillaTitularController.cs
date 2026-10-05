using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
//ten q catryea tod
namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantillaTitularController : ControllerBase
    {
        private readonly ServicePlantillaTitular _service;

        public PlantillaTitularController(ServicePlantillaTitular servicePlantillaTitular)
        {
            _service = servicePlantillaTitular;
        }

        [HttpPost]
        public ActionResult<PlantillaTitular> Agregar(PlantillaTitular plantillaTitular)
        {
            try
            {
                var nuevaPlantillaTitular = _service.Agregar(plantillaTitular);
                return Ok(nuevaPlantillaTitular);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<PlantillaTitular>> Obtener()
        {
            try
            {
                var plantillasTitulares = _service.ObtenerTodos();
                return Ok(plantillasTitulares);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PlantillaTitular> ObtenerPorId(int id)
        {
            try
            {
                var plantillaTitular = _service.ObtenerPorId(id);
                if (plantillaTitular == null)
                {
                    return NotFound();
                }
                return Ok(plantillaTitular);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("titulares/{id}")]
        public ActionResult<List<Jugador>> ObtenerTitularesPlantilla(int id)
        {
            try
            {
                var titulares = _service.ObtenerTitularesPlantilla(id);
                return Ok(titulares);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var eliminado = _service.Eliminar(id);
                if (!eliminado)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}