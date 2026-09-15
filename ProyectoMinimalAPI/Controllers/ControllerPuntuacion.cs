using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPuntuacion : ControllerBase
    {
        private readonly ServicePuntuacion _service;

        public ControllerPuntuacion(ServicePuntuacion servicePuntuacion)
        {
            _service = servicePuntuacion;
        }

        [HttpPost]
        public IActionResult<Puntuacion> Agregar(Puntuacion puntuacion)
        {
            if (puntuacion.Fecha == 0)
                return BadRequest();
            if (puntuacion.IdJugador == 0)
                return BadRequest();
            if (puntuacion.Puntuacion == null)
                return BadRequest();
            var nuevaPuntuacion = _service.Agregar(puntuacion);
            return Ok(nuevaPuntuacion);
        }

        [HttpGet]
        public IActionResult<List<Puntuacion>> Obtener()
        {
            var puntuaciones = _service.ObtenerTodos();
            return Ok(puntuaciones);
        }
        
        [HttpGet("fecha/{fecha}")]
        public IActionResult<Puntuacion> ObtenerPorFecha(byte fecha)
        {
            var puntuacion = _service.ObtenerPorFecha(fecha);
            if (puntuacion == null)
            {
                return NotFound();
            }
            return Ok(puntuacion);
        }

        [HttpGet("jugador/{id}")]
        public IActionResult<Puntuacion> ObtenerPorJugador(ushort id)
        {
            var puntuacion = _service.ObtenerPorJugador(id);
            if (puntuacion == null)
            {
                return NotFound();
            }
            return Ok(puntuacion);
        }

        [HttpGet("fecha/{fecha}/jugador/{id}")]
        public IActionResult<Puntuacion> ObtenerPorFechaJugador(byte fecha, ushort id)
        {
            var puntuacion = _service.ObtenerPorFechaJugador(fecha, id);
            if (puntuacion == null)
            {
                return NotFound();
            }
            return Ok(puntuacion);
        }

        [HttpGet("jugadores/{id}")]
        public IActionResult<List<Jugador>> ObtenerJugadoresPorPuntuacion(int id)
        {
            var jugadores = _service.ObtenerJugadoresPorPuntuacion(id);
            return Ok(jugadores);
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