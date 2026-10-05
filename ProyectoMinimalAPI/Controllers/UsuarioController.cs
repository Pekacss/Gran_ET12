using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ServiceUsuario _service;

        public UsuarioController(ServiceUsuario serviceUsuario)
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
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult<object> IniciarSesion(Usuario credenciales)
        {
            try
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
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<object>> Obtener()
        {
            try
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
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<object> ObtenerPorId(ushort id)
        {
            try
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
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(ushort id)
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