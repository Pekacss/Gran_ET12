using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServiceUsuario : IRepoUsuario
    {
        private const int IteracionesHash = 600000;
        private const int LongitudSal = 16;
        private const int LongitudHash = 32;
        private readonly IRepoUsuario _repoUsuario;

        public ServiceUsuario(IRepoUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public Usuario Agregar(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            if (string.IsNullOrWhiteSpace(usuario.Nombre)
                || string.IsNullOrWhiteSpace(usuario.Apellido)
                || string.IsNullOrWhiteSpace(usuario.Email)
                || usuario.FechaNacimiento == DateTime.MinValue
                || string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                throw new ArgumentException("Faltan datos obligatorios del usuario.", nameof(usuario));
            }

            usuario.Contraseña = HashearContraseña(usuario.Contraseña);
            return _repoUsuario.Agregar(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repoUsuario.ObtenerTodos();
        }

        public Usuario? ObtenerPorId(ushort id)
        {
            return _repoUsuario.ObtenerPorId(id);
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            return _repoUsuario.ObtenerPorEmail(email);
        }

        public Usuario? IniciarSesion(string email, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contraseña))
                return null;

            Usuario? usuario = _repoUsuario.ObtenerPorEmail(email);
            if (usuario == null || !VerificarContraseña(contraseña, usuario.Contraseña))
                return null;

            return usuario;
        }

        public bool Eliminar(ushort id)
        {
            return _repoUsuario.Eliminar(id);
        }

        private static string HashearContraseña(string contraseña)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(LongitudSal);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(contraseña),
                sal,
                IteracionesHash,
                HashAlgorithmName.SHA256,
                LongitudHash);
            byte[] datosGuardados = new byte[LongitudSal + LongitudHash];
            Buffer.BlockCopy(sal, 0, datosGuardados, 0, sal.Length);
            Buffer.BlockCopy(hash, 0, datosGuardados, sal.Length, hash.Length);
            return Convert.ToBase64String(datosGuardados);
        }

        private static bool VerificarContraseña(string contraseña, string hashGuardado)
        {
            byte[] datosGuardados;
            try
            {
                datosGuardados = Convert.FromBase64String(hashGuardado);
            }
            catch (FormatException)
            {
                return false;
            }

            if (datosGuardados.Length != LongitudSal + LongitudHash)
                return false;

            byte[] sal = new byte[LongitudSal];
            byte[] hashEsperado = new byte[LongitudHash];
            Buffer.BlockCopy(datosGuardados, 0, sal, 0, sal.Length);
            Buffer.BlockCopy(datosGuardados, sal.Length, hashEsperado, 0, hashEsperado.Length);

            byte[] hashIngresado = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(contraseña),
                sal,
                IteracionesHash,
                HashAlgorithmName.SHA256,
                LongitudHash);

            return CryptographicOperations.FixedTimeEquals(hashEsperado, hashIngresado);
        }
    }
}
