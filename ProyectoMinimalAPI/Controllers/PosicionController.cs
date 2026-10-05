using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosicionController : ControllerBase
    {
        private readonly ServicePosicion _service;

        public PosicionController(ServicePosicion servicePosicion)
        {
            _service = servicePosicion;
        }

        [HttpPost]
        public ActionResult<Posicion> Agregar(Posicion posicion)
        {
            try
            {
                if (!posicion.EsValida())
                    return BadRequest();
                var nuevaPosicion = _service.Agregar(posicion);
                return Ok(nuevaPosicion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Posicion>> Obtener()
        {
            try
            {
                var posiciones = _service.ObtenerTodos();
                return Ok(posiciones);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Posicion> ObtenerPorId(byte id)
        {
            try
            {
                var posicion = _service.ObtenerPorId(id);
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

        [HttpGet("jugadores/{id}")]
        public ActionResult<List<Jugador>> ObtenerJugadoresPorPosicion(byte id)
        {
            try
            {
                var jugadores = _service.ObtenerJugadoresPorPosicion(id);
                return Ok(jugadores);
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
    }
}