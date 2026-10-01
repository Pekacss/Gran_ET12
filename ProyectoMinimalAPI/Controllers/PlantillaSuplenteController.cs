using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPlantillaSuplente : ControllerBase
    {
        private readonly ServicePlantillaSuplente _service;

        public ControllerPlantillaSuplente(ServicePlantillaSuplente servicePlantillaSuplente)
        {
            _service = servicePlantillaSuplente;
        }

        [HttpPost]
        public ActionResult<PlantillaSuplente> Agregar(PlantillaSuplente plantillaSuplente)
        {
            if (plantillaSuplente.Id == 0)
                return BadRequest();
            if (plantillaSuplente.IdPlantilla == 0)
                return BadRequest();
            if (plantillaSuplente.IdJugador == 0)
                return BadRequest();
            var nuevaPlantillaSuplente = _service.Agregar(plantillaSuplente);
            return Ok(nuevaPlantillaSuplente);
        }

        [HttpGet]
        public ActionResult<List<PlantillaSuplente>> Obtener()
        {
            var plantillasSuplentes = _service.ObtenerTodos();
            return Ok(plantillasSuplentes);
        }

        [HttpGet("{id}")]
        public ActionResult<PlantillaSuplente> ObtenerPorId(int id)
        {
            var plantillaSuplente = _service.ObtenerPorId(id);
            if (plantillaSuplente == null)
            {
                return NotFound();
            }
            return Ok(plantillaSuplente);
        }

        [HttpGet("suplentes/{id}")]
        public ActionResult<List<Jugador>> ObtenerSuplentesPlantilla(int id)
        {
            var suplentes = _service.ObtenerSuplentesPlantilla(id);
            return Ok(suplentes);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var eliminado = _service.Eliminar(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}