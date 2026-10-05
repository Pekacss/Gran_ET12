using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantillaController : ControllerBase
    {
        private readonly ServicePlantilla _service;

        public PlantillaController(ServicePlantilla servicePlantilla)
        {
            _service = servicePlantilla;
        }

        [HttpPost]
        public ActionResult<Plantilla> Agregar(Plantilla plantilla)
        {
            try
            {
                if (!plantilla.EsValida())
                    return BadRequest();
                var nuevaPlantilla = _service.Agregar(plantilla);
                return Ok(nuevaPlantilla);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Plantilla>> ObtenerTodos()
        {
            try
            {
                var plantillas = _service.ObtenerTodos();
                return Ok(plantillas);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<Plantilla> ObtenerPorIdUsuario(ushort id)
        {
            try
            {
                var plantilla = _service.ObtenerPorIdUsuario(id);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(plantilla);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fecha/{fecha}")]
        public ActionResult<Plantilla> ObtenerPorFecha(byte fecha)
        {
            try
            {
                var plantilla = _service.ObtenerPorFecha(fecha);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(plantilla);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("nombre/{nombre}")]
        public ActionResult<Plantilla> ObtenerPorNombre(string nombre)
        {
            try
            {
                var plantilla = _service.ObtenerPorNombre(nombre);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(plantilla);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Plantilla> ObtenerPorId(int id)
        {
            try
            {
                var plantilla = _service.ObtenerPorId(id);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(plantilla);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/jugadores")]
        public ActionResult<List<Jugador>> ObtenerJugadoresPorPlantilla(int id)
        {
            try
            {
                var jugadores = _service.ObtenerJugadoresPorPlantilla(id);
                return Ok(jugadores);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/calificacion")]
        public ActionResult<decimal> ObtenerCalificacionPlantilla(int id)
        {
            try
            {
                var calificacion = _service.ObtenerCalificacionPlantilla(id);
                return Ok(calificacion);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
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