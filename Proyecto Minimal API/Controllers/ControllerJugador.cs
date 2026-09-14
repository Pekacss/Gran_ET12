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
        public IActionResult<Jugador> Agregar(Jugador jugador)
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
        public IActionResult<List<Jugador>> Obtener()
        {
            var jugadores = _service.ObtenerTodos();
            return Ok(jugadores);
        }

        [HttpGet("{id}")]
        public IActionResult<Jugador> ObtenerPorId(int id)
        {
            var jugador = _service.ObtenerPorId(id);
            if (jugador == null)
            {
                return NotFound();
            }
            return Ok(jugador);
        }

        [HttpGet("equipo/{id}")]
        public IActionResult<Equipo> ObtenerEquipoPorjugador(int id)
        {
            var equipo = _service.ObtenerEquipoPorjugador(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        [HttpGet("posicion/{id}")]
        public IActionResult<Posicion> ObtenerPosicionPorjugador(int id)
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