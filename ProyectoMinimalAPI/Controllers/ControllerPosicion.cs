using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPosicion : ControllerBase
    {
        private readonly ServicePosicion _service;

        public ControllerPosicion(ServicePosicion servicePosicion)
        {
            _service = servicePosicion;
        }

        [HttpPost]
        public ActionResult<Posicion> Agregar(Posicion posicion)
        {
            if (posicion.Id == null || posicion.Id == 0)
                return BadRequest();
            if (string.IsNullOrEmpty(posicion.Nombre))
                return BadRequest();
            var nuevaPosicion = _service.Agregar(posicion);
            return Ok(nuevaPosicion);
        }

        [HttpGet]
        public ActionResult<List<Posicion>> Obtener()
        {
            var posiciones = _service.ObtenerTodos();
            return Ok(posiciones);
        }

        [HttpGet("{id}")]
        public ActionResult<Posicion> ObtenerPorId(byte id)
        {
            var posicion = _service.ObtenerPorId(id);
            if (posicion == null)
            {
                return NotFound();
            }
            return Ok(posicion);
        }

        [HttpGet("jugadores/{id}")]
        public ActionResult<List<Jugador>> ObtenerJugadoresPorPosicion(byte id)
        {
            var jugadores = _service.ObtenerJugadoresPorPosicion(id);
            return Ok(jugadores);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(byte id)
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