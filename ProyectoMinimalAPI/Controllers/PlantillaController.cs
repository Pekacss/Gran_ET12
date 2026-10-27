using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;


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
        public IActionResult Agregar(Plantilla plantilla)
        {
            try
            {
                var nuevaPlantilla = _service.Agregar(plantilla);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaPlantilla.Id }, new PlantillaDTO(nuevaPlantilla));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var plantillas = _service.ObtenerTodos();
                return Ok(plantillas.Select(p => new PlantillaDTO(p)).ToList());
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("usuario/{id}")]
        public IActionResult ObtenerPorIdUsuario(ushort id)
        {
            try
            {
                var plantilla = _service.ObtenerPorIdUsuario(id);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(new PlantillaDTO(plantilla));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fecha/{fecha}")]
        public IActionResult ObtenerPorFecha(byte fecha)
        {
            try
            {
                var plantilla = _service.ObtenerPorFecha(fecha);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(new PlantillaDTO(plantilla));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("nombre/{nombre}")]
        public IActionResult ObtenerPorNombre(string nombre)
        {
            try
            {
                var plantilla = _service.ObtenerPorNombre(nombre);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(new PlantillaDTO(plantilla));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var plantilla = _service.ObtenerPorId(id);
                if (plantilla == null)
                {
                    return NotFound();
                }
                return Ok(new PlantillaDTO(plantilla));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/jugadores")]
        public IActionResult ObtenerJugadoresPorPlantilla(int id)
        {
            try
            {
                var jugadores = _service.ObtenerJugadoresPorPlantilla(id);
                return Ok(jugadores.Select(j => new JugadorDTO(j)).ToList());
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