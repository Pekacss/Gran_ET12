using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantillaSuplenteController : ControllerBase
    {
        private readonly ServicePlantillaSuplente _service;

        public PlantillaSuplenteController(ServicePlantillaSuplente servicePlantillaSuplente)
        {
            _service = servicePlantillaSuplente;
        }

        [HttpPost]
        public IActionResult Agregar(PlantillaSuplenteDTO plantillaSuplenteDTO)
        {
            try
            {
                var nuevaPlantillaSuplente = _service.Agregar(plantillaSuplenteDTO.AModelo());
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaPlantillaSuplente.IdPlantilla }, new PlantillaSuplenteDTO(nuevaPlantillaSuplente));
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
                var plantillasSuplentes = _service.ObtenerTodos();
                return Ok(plantillasSuplentes.Select(s => new PlantillaSuplenteDTO(s)).ToList());
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
                var plantillaSuplente = _service.ObtenerPorId(id);
                if (plantillaSuplente == null)  
                {
                    return NotFound();
                }
                return Ok(new PlantillaSuplenteDTO(plantillaSuplente));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("suplentes/{id}")]
        public IActionResult ObtenerSuplentesPlantilla(int id)
        {
            try
            {
                var suplentes = _service.ObtenerSuplentesPlantilla(id);
                return Ok(suplentes.Select(s => new JugadorDTO(s)).ToList());
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