using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;

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
        public IActionResult Agregar(Posicion posicion)
        {
            try
            {
                var nuevaPosicion = _service.Agregar(posicion);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaPosicion.Id }, new PosicionDTO(nuevaPosicion));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            try
            {
                var posiciones = _service.ObtenerTodos();
                return Ok(posiciones.Select(p => new PosicionDTO(p)).ToList());
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(byte id)
        {
            try
            {
                var posicion = _service.ObtenerPorId(id);
                if (posicion == null)
                {
                    return NotFound();
                }
                return Ok(new PosicionDTO(posicion));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("jugadores/{id}")]
        public IActionResult ObtenerJugadoresPorPosicion(byte id)
        {
            try
            {
                var jugadores = _service.ObtenerJugadoresPorPosicion(id);
                return Ok(jugadores.Select(j => new JugadorDTO(j)).ToList());
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