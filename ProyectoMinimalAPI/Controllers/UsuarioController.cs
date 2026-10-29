using System;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using dto;

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
        public IActionResult Agregar(UsuarioPostDTO usuarioDTO)
        {
            Usuario nuevoUsuario;
            try
            {
                nuevoUsuario = _service.Agregar(usuarioDTO.AModelo());
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoUsuario.Id }, new UsuarioPostDTO(nuevoUsuario));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);
                return StatusCode(500, ex.Message);
            } // Usamos DTO para devolver solo los datos necesarios
        }

        [HttpPost("login")]
        public IActionResult IniciarSesion(UsuarioLoginDTO credenciales)
        {
            try
            {
                Usuario? usuario = _service.IniciarSesion(credenciales.Email, credenciales.Contraseña);
                if (usuario == null)
                    return Unauthorized();
    
                return Ok(new UsuarioLoginDTO(usuario));
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
                var usuarios = _service.ObtenerTodos();
                List<UsuarioGetDTO> respuesta = new List<UsuarioGetDTO>();
                foreach (Usuario usuario in usuarios)
                {
                    respuesta.Add(new UsuarioGetDTO(usuario));
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
        public IActionResult ObtenerPorId(ushort id)
        {
            try
            {
                Usuario? usuario = _service.ObtenerPorId(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(new UsuarioGetDTO(usuario));
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