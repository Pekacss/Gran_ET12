using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JugadorController : ControllerBase
    {
        private readonly ServiceJugador _service;

        public JugadorController(ServiceJugador serviceJugador)
        {
            _service = serviceJugador;
        }

        [HttpPost]
        public ActionResult<Jugador> Agregar(Jugador jugador)
        {
            try
            {
                if (!jugador.EsValido())
                    return BadRequest();
                var nuevoJugador = _service.Agregar(jugador);
                return Ok(nuevoJugador);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Jugador>> Obtener()
        {
            try
            {
                var jugadores = _service.ObtenerTodos();
                return Ok(jugadores);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Jugador> ObtenerPorId(ushort id)
        {
            try
            {
                var jugador = _service.ObtenerPorId(id);
                if (jugador == null)
                {
                    return NotFound();
                }
                return Ok(jugador);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("equipo/{id}")]
        public ActionResult<Equipo> ObtenerEquipoPorJugador(ushort id)
        {
            try
            {
                var equipo = _service.ObtenerEquipoPorJugador(id);
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

        [HttpGet("posicion/{id}")]
        public ActionResult<Posicion> ObtenerPosicionPorJugador(ushort id)
        {
            try
            {
                var posicion = _service.ObtenerPosicionPorJugador(id);
                if (posicion == null)
                {
                    return NotFound();
                }
                return Ok(posicion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(ushort id)
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