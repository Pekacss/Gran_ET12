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
        public ActionResult<object> Agregar(Usuario usuario)
        {
            try
            {
                var nuevoUsuario = _service.Agregar(usuario);
                return Ok(new
                {
                    nuevoUsuario.Id,
                    nuevoUsuario.Nombre,
                    nuevoUsuario.Apellido,
                    nuevoUsuario.Email,
                    nuevoUsuario.FechaNacimiento,
                    nuevoUsuario.Administrador
                });
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public ActionResult<object> IniciarSesion(Usuario credenciales)
        {
            Usuario? usuario = _service.IniciarSesion(credenciales.Email, credenciales.Contraseña);
            if (usuario == null)
                return Unauthorized();

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Email,
                usuario.FechaNacimiento,
                usuario.Administrador
            });
        }

        [HttpGet]
        public ActionResult<List<object>> Obtener()
        {
            var usuarios = _service.ObtenerTodos();
            List<object> respuesta = new List<object>();
            foreach (Usuario usuario in usuarios)
            {
                respuesta.Add(new
                {
                    usuario.Id,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Email,
                    usuario.FechaNacimiento,
                    usuario.Administrador
                });
            }

            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public ActionResult<object> ObtenerPorId(ushort id)
        {
            var usuario = _service.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Email,
                usuario.FechaNacimiento,
                usuario.Administrador
            });
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