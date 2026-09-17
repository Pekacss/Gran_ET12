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
            if (jugador.Id == null)
                return BadRequest();
            if (string.IsNullOrEmpty(jugador.Nombre))
                return BadRequest();
            if (string.IsNullOrEmpty(jugador.Apellido))
                return BadRequest();
            if (jugador.FechaNacimiento == DateTime.MinValue)
                return BadRequest();
            if (jugador.EquipoId == null)
                return BadRequest();
            if (jugador.PosicionId == null)
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
        public ActionResult<Jugador> ObtenerPorId(int id)
        {
            var jugador = _service.ObtenerPorId(id);
            if (jugador == null)
            {
                return NotFound();
            }
            return Ok(jugador);
        }

        [HttpGet("equipo/{id}")]
        public ActionResult<Equipo> ObtenerEquipoPorjugador(int id)
        {
            var equipo = _service.ObtenerEquipoPorjugador(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        [HttpGet("posicion/{id}")]
        public ActionResult<Posicion> ObtenerPosicionPorjugador(int id)
        {
            var posicion = _service.ObtenerPosicionPorjugador(id);
            if (posicion == null)
            {
                return NotFound();
            }
            return Ok(posicion);
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