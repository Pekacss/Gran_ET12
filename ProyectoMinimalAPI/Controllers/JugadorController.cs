using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerJugador : ControllerBase
    {
        private readonly ServiceJugador _service;

        public ControllerJugador(ServiceJugador serviceJugador)
        {
            _service = serviceJugador;
        }

        [HttpPost]
        public ActionResult<Jugador> Agregar(Jugador jugador)
        {
            if (!jugador.EsValido())
                return BadRequest();
            var nuevoJugador = _service.Agregar(jugador);
            return Ok(nuevoJugador);
        }

        [HttpGet]
        public ActionResult<List<Jugador>> Obtener()
        {
            var jugadores = _service.ObtenerTodos();
            return Ok(jugadores);
        }

        [HttpGet("{id}")]
        public ActionResult<Jugador> ObtenerPorId(ushort id)
        {
            var jugador = _service.ObtenerPorId(id);
            if (jugador == null)
            {
                return NotFound();
            }
            return Ok(jugador);
        }

        [HttpGet("equipo/{id}")]
        public ActionResult<Equipo> ObtenerEquipoPorJugador(ushort id)
        {
            var equipo = _service.ObtenerEquipoPorJugador(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        [HttpGet("posicion/{id}")]
        public ActionResult<Posicion> ObtenerPosicionPorJugador(ushort id)
        {
            var posicion = _service.ObtenerPosicionPorJugador(id);
            if (posicion == null)
            {
                return NotFound();
            }
            return Ok(posicion);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(ushort id)
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