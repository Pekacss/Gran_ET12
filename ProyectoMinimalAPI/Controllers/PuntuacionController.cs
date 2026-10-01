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
            if (puntuacion.Fecha == 0)
                return BadRequest();
            if (puntuacion.IdJugador == 0)
                return BadRequest();
            if (puntuacion.Puntaje == 0)
                return BadRequest();
            var nuevaPuntuacion = _service.Agregar(puntuacion);
            return Ok(nuevaPuntuacion);
        }

        [HttpGet]
        public ActionResult<List<Puntuacion>> Obtener()
        {
            var puntuaciones = _service.ObtenerTodos();
            return Ok(puntuaciones);
        }
        
        [HttpGet("fecha/{fecha}")]
        public ActionResult<Puntuacion> ObtenerPorFecha(byte fecha)
        {
            var puntuacion = _service.ObtenerPorFecha(fecha);
            if (puntuacion == null)
            {
                return NotFound();
            }
            return Ok(puntuacion);
        }

        [HttpGet("jugador/{id}")]
        public ActionResult<Puntuacion> ObtenerPorJugador(ushort id)
        {
            var puntuacion = _service.ObtenerPorJugador(id);
            if (puntuacion == null)
            {
                return NotFound();
            }
            return Ok(puntuacion);
        }

        [HttpGet("fecha/{fecha}/jugador/{id}")]
        public ActionResult<Puntuacion> ObtenerPorFechaJugador(byte fecha, ushort id)
        {
            var puntuacion = _service.ObtenerPorFechaJugador(fecha, id);
            if (puntuacion == null)
            {
                return NotFound();
            }
            return Ok(puntuacion);
        }

        [HttpDelete("fecha/{fecha}/jugador/{idJugador}")]
        public IActionResult Eliminar(byte fecha, ushort idJugador)
        {
            var eliminado = _service.Eliminar(fecha, idJugador);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}