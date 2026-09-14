using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPlantilla : ControllerBase
    {
        private readonly ServicePlantilla _service;

        public ControllerPlantilla(ServicePlantilla servicePlantilla)
        {
            _service = servicePlantilla;
        }

        [HttpPost]
        public IActionResult<Plantilla> Agregar(Plantilla plantilla)
        {
            if (plantilla.Id == 0)
                return BadRequest();
            if (plantilla.Fecha == 0)
                return BadRequest();
            var nuevaPlantilla = _service.Agregar(plantilla);
            return Ok(nuevaPlantilla);
        }

        [HttpGet]
        public IActionResult<List<Plantilla>> Obtener()
        {
            var plantillas = _service.ObtenerTodos();
            return Ok(plantillas);
        }

        [HttpGet("{id}")]
        public IActionResult<Plantilla> ObtenerPorId(int id)
        {
            var plantilla = _service.ObtenerPorId(id);
            if (plantilla == null)
            {
                return NotFound();
            }
            return Ok(plantilla);
        }

        [HttpGet("{id}/jugadores")]
        public IActionResult<List<Jugador>> ObtenerJugadoresPorPlantilla(int id)
        {
            var jugadores = _service.ObtenerJugadoresPorPlantilla(id);
            return Ok(jugadores);
        }

        [HttpGet("{id}/calificacion")]
        public IActionResult<float> ObtenerCalificacionPlantilla(int id)
        {
            var calificacion = _service.ObtenerCalificacionPlantilla(id);
            return Ok(calificacion);
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