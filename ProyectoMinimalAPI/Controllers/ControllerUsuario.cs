using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerUsuario : ControllerBase
    {
        private readonly ServiceUsuario _service;

        public ControllerUsuario(ServiceUsuario serviceUsuario)
        {
            _service = serviceUsuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Agregar(Usuario usuario)
        {
            if (usuario.Id == null)
                return BadRequest();
            if (string.IsNullOrEmpty(usuario.Nombre))
                return BadRequest();
            if (string.IsNullOrEmpty(usuario.Apellido))
                return BadRequest();
            if (string.IsNullOrEmpty(usuario.Email))
                return BadRequest();
            if (string.IsNullOrEmpty(usuario.Contraseña))
                return BadRequest();
            if (usuario.FechaNacimiento == DateTime.MinValue)
                return BadRequest();
            var nuevoUsuario = _service.Agregar(usuario);
            return Ok(nuevoUsuario);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Obtener()
        {
            var usuarios = _service.ObtenerTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> ObtenerPorId(ushort id)
        {
            var usuario = _service.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(ushort id)
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