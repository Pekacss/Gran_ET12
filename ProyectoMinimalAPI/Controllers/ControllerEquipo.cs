using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerEquipo : ControllerBase
    {
        private readonly ServiceEquipo _service;

        public ControllerEquipo(ServiceEquipo serviceEquipo)
        {
            _service = serviceEquipo;
        }

        [HttpPost]
        public IActionResult<Equipo> Agregar(Equipo equipo)
        {
            if (equipo.Id == null)
                return BadRequest();
            if (string.IsNullOrEmpty(equipo.Nombre))
                return BadRequest();
            var nuevoEquipo = _service.Agregar(equipo);
            return Ok(nuevoEquipo);
        }

        [HttpGet]
        public IActionResult<List<Equipo>> Obtener()
        {
            var equipos = _service.ObtenerTodos();
            return Ok(equipos);
        }

        [HttpGet("{id}")]
        public IActionResult<Equipo> ObtenerPorId(int id)
        {
            var equipo = _service.ObtenerPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
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

        [HttpGet("{id}/jugadores")]
        public IActionResult<List<Jugador>> ObtenerJugadoresPorEquipo(int id)
        {
            var jugadores = _service.ObtenerJugadoresPorEquipo(id);
            return Ok(jugadores);
        }
    }
}