using System;
using Models;
using dto;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;

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
        public IActionResult Agregar(Equipo equipo)
        {
            try
            {
                var nuevoEquipo = _service.Agregar(equipo);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoEquipo.Id }, new EquipoDTO(nuevoEquipo));
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
        public IActionResult Obtener()
        {
            try
            {
                var equipos = _service.ObtenerTodos();
                List<EquipoDTO> respuesta = new List<EquipoDTO>();
                foreach (var equipo in equipos)
                {
                    respuesta.Add(new EquipoDTO(equipo));
                }
                return Ok(respuesta);
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
                var equipo = _service.ObtenerPorId(id);
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
        public IActionResult ObtenerJugadoresPorEquipo(byte id)
        {
            try
            {
                var jugadores = _service.ObtenerJugadoresPorEquipo(id);
                return Ok(jugadores.Select(j => new JugadorDTO(j)));
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