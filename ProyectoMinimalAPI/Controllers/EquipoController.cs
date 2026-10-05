using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipoController : ControllerBase
    {
        private readonly ServiceEquipo _service;

        public EquipoController(ServiceEquipo serviceEquipo)
        {
            _service = serviceEquipo;
        }

        [HttpPost]
        public ActionResult<Equipo> Agregar(Equipo equipo)
        {
            try
            {
                var nuevoEquipo = _service.Agregar(equipo);
                return Ok(nuevoEquipo);
            }
            catch (Exception ex)
            {
                //Tengo que ver que tipo de excepcion rebota
                // 500: Errores en la capa de datos o lógica interna
                // 400: Errores de validación o argumentos incorrectos
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Equipo>> Obtener()
        {
            try
            {
                var equipos = _service.ObtenerTodos();
                return Ok(equipos);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Equipo> ObtenerPorId(byte id)
        {
            try
            {
                var equipo = _service.ObtenerPorId(id);
                if (equipo == null)
                {
                    return NotFound();
                }
                return Ok(equipo);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(byte id)
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

        [HttpGet("{id}/jugadores")]
        public ActionResult<List<Jugador>> ObtenerJugadoresPorEquipo(byte id)
        {
            try
            {
                var jugadores = _service.ObtenerJugadoresPorEquipo(id);
                return Ok(jugadores);
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