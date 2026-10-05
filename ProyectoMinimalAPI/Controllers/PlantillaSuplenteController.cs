using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantillaSuplenteController : ControllerBase
    {
        private readonly ServicePlantillaSuplente _service;

        public PlantillaSuplenteController(ServicePlantillaSuplente servicePlantillaSuplente)
        {
            _service = servicePlantillaSuplente;
        }

        [HttpPost]
        public ActionResult<PlantillaSuplente> Agregar(PlantillaSuplente plantillaSuplente)
        {
            try
            {
                var nuevaPlantillaSuplente = _service.Agregar(plantillaSuplente);
                return Ok(nuevaPlantillaSuplente);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<PlantillaSuplente>> Obtener()
        {
            try
            {
                var plantillasSuplentes = _service.ObtenerTodos();
                return Ok(plantillasSuplentes);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PlantillaSuplente> ObtenerPorId(int id)
        {
            try
            {
                var plantillaSuplente = _service.ObtenerPorId(id);
                if (plantillaSuplente == null)
                {
                    return NotFound();
                }
                return Ok(plantillaSuplente);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("suplentes/{id}")]
        public ActionResult<List<Jugador>> ObtenerSuplentesPlantilla(int id)
        {
            try
            {
                var suplentes = _service.ObtenerSuplentesPlantilla(id);
                return Ok(suplentes);
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