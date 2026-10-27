using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;
namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantillaTitularController : ControllerBase
    {
        private readonly ServicePlantillaTitular _service;

        public PlantillaTitularController(ServicePlantillaTitular servicePlantillaTitular)
        {
            _service = servicePlantillaTitular;
        }

        [HttpPost]
        public IActionResult Agregar(PlantillaTitular plantillaTitular)
        {
            try
            {
                var nuevaPlantillaTitular = _service.Agregar(plantillaTitular);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaPlantillaTitular.IdPlantilla }, new PlantillaTitularDTO(nuevaPlantillaTitular));
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
                var titulares = _service.ObtenerTodos();
                return Ok(titulares.Select(t => new PlantillaTitularDTO(t)).ToList());
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
                var plantillaTitular = _service.ObtenerPorId(id);
                if (plantillaTitular == null)
                {
                    return NotFound();
                }
                return Ok(new PlantillaTitularDTO(plantillaTitular));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("titulares/{id}")]
        public IActionResult ObtenerTitularesPlantilla(int id)
        {
            try
            {
                var titulares = _service.ObtenerTitularesPlantilla(id);
                return Ok(titulares.Select(t => new JugadorDTO(t)).ToList());
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