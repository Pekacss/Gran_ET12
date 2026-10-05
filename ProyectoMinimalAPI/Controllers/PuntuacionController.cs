using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuntuacionController : ControllerBase
    {
        private readonly ServicePuntuacion _service;

        public PuntuacionController(ServicePuntuacion servicePuntuacion)
        {
            _service = servicePuntuacion;
        }

        [HttpPost]
        public ActionResult<Puntuacion> Agregar(Puntuacion puntuacion)
        {
            try
            {
                if (puntuacion.EsValida())
                    return BadRequest();
                var nuevaPuntuacion = _service.Agregar(puntuacion);
                return Ok(nuevaPuntuacion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Puntuacion>> Obtener()
        {
            try
            {
                var puntuaciones = _service.ObtenerTodos();
                return Ok(puntuaciones);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("fecha/{fecha}")]
        public ActionResult<Puntuacion> ObtenerPorFecha(byte fecha)
        {
            try
            {
                var puntuacion = _service.ObtenerPorFecha(fecha);
                if (puntuacion == null)
                    return NotFound();
                return Ok(puntuacion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("jugador/{id}")]
        public ActionResult<Puntuacion> ObtenerPorJugador(ushort id)
        {
            try
            {
                var puntuacion = _service.ObtenerPorJugador(id);
                if (puntuacion == null)
                    return NotFound();
                return Ok(puntuacion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fecha/{fecha}/jugador/{id}")]
        public ActionResult<Puntuacion> ObtenerPorFechaJugador(byte fecha, ushort id)
        {
            try
            {
                var puntuacion = _service.ObtenerPorFechaJugador(fecha, id);
                if (puntuacion == null)
                    return NotFound();
                
                return Ok(puntuacion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("fecha/{fecha}/jugador/{idJugador}")]
        public IActionResult Eliminar(byte fecha, ushort idJugador)
        {
            try
            {
                var eliminado = _service.Eliminar(fecha, idJugador);
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