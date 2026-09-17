using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPlantillaTitular : ControllerBase
    {
        private readonly ServicePlantillaTitular _service;

        public ControllerPlantillaTitular(ServicePlantillaTitular servicePlantillaTitular)
        {
            _service = servicePlantillaTitular;
        }

        [HttpPost]
        public ActionResult<PlantillaTitular> Agregar(PlantillaTitular plantillaTitular)
        {
            if (plantillaTitular.Id == null || plantillaTitular.Id == 0)
                return BadRequest();
            if (plantillaTitular.IdPlantilla == null || plantillaTitular.IdPlantilla == 0)
                return BadRequest();
            if (plantillaTitular.IdJugador == null || plantillaTitular.IdJugador == 0)
                return BadRequest();
            var nuevaPlantillaTitular = _service.Agregar(plantillaTitular);
            return Ok(nuevaPlantillaTitular);
        }

        [HttpGet]
        public ActionResult<List<PlantillaTitular>> Obtener()
        {
            var plantillasTitulares = _service.ObtenerTodos();
            return Ok(plantillasTitulares);
        }

        [HttpGet("{id}")]
        public ActionResult<PlantillaTitular> ObtenerPorId(int id)
        {
            var plantillaTitular = _service.ObtenerPorId(id);
            if (plantillaTitular == null)
            {
                return NotFound();
            }
            return Ok(plantillaTitular);
        }

        [HttpGet("titulares/{id}")]
        public ActionResult<List<Jugador>> ObtenerTitularesPlantilla(int id)
        {
            var titulares = _service.ObtenerTitularesPlantilla(id);
            return Ok(titulares);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var eliminado = _service.Eliminar(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}