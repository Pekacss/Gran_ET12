using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;

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
        public IActionResult Agregar(JugadorDTO jugadorDTO)
        {
            try
            {
                var nuevoJugador = _service.Agregar(jugadorDTO.AModelo());
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoJugador.Id }, new JugadorDTO(nuevoJugador));
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
                var jugadores = _service.ObtenerTodos();
                return Ok(jugadores.Select(j => new JugadorDTO(j)).ToList());
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(ushort id)
        {
            try
            {
                var jugador = _service.ObtenerPorId(id);
                if (jugador == null)
                {
                    return NotFound();
                }
                return Ok(new JugadorDTO(jugador));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("equipo/{id}")]
        public IActionResult ObtenerEquipoPorJugador(ushort id)
        {
            try
            {
                var equipo = _service.ObtenerEquipoPorJugador(id);
                if (equipo == null)
                {
                    return NotFound();
                }
                return Ok(new EquipoDTO(equipo));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("posicion/{id}")]
        public IActionResult ObtenerPosicionPorJugador(ushort id)
        {
            try
            {
                var posicion = _service.ObtenerPosicionPorJugador(id);
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