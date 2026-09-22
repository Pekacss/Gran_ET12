using System.Collections.Generic;

namespace Models
{
    public class Plantilla
    {
        public int Id { get; set; }
        public ushort IdUsuario { get; set; }
        public byte Fecha { get; set; }
        public string? Nombre { get; set; }

        public const int CantidadMaximaJugadoresPredeterminada = 20;
        public decimal PresupuestoMaximo { get; set; } = decimal.MaxValue;
        public int CantidadMaximaJugadores { get; set; } = CantidadMaximaJugadoresPredeterminada;

        private readonly List<Jugador> _titulares = new List<Jugador>();
        private readonly List<Jugador> _suplentes = new List<Jugador>();

        public List<Jugador> Titulares { get { return _titulares; } }

        public List<Jugador> Suplentes { get { return _suplentes; } }

        public void AgregarTitular(Jugador jugador)
        {
            AgregarJugador(jugador, _titulares);
        }

        public void AgregarSuplente(Jugador jugador)
        {
            AgregarJugador(jugador, _suplentes);
        }

        public decimal ObtenerPresupuesto()
        {
            decimal presupuesto = 0m;

            foreach (Jugador jugador in _titulares)
            {
                presupuesto += jugador.Cotizacion;
            }

            foreach (Jugador jugador in _suplentes)
            {
                presupuesto += jugador.Cotizacion;
            }

            return presupuesto;
        }

        public bool PresupuestoValido()
        {
            return ObtenerPresupuesto() <= PresupuestoMaximo;
        }

        public bool CantidadJugadoresValida()
        {
            return CantidadMaximaJugadores > 0
                && _titulares.Count + _suplentes.Count <= CantidadMaximaJugadores;
        }

        public bool FormacionTitularValida()
        {
            int arqueros = 0;
            int defensores = 0;
            int mediocampistas = 0;
            int delanteros = 0;

            foreach (Jugador jugador in _titulares)
            {
                if (jugador.IdPosicion == Posicion.Arquero)
                    arqueros++;
                if (jugador.IdPosicion == Posicion.Defensor)
                    defensores++;
                if (jugador.IdPosicion == Posicion.Mediocampista)
                    mediocampistas++;
                if (jugador.IdPosicion == Posicion.Delantero)
                    delanteros++;
            }

            return arqueros == 1
                && defensores == 4
                && mediocampistas == 4
                && delanteros == 2;
        }

        public bool EsValida()
        {
            return FormacionTitularValida()
                && CantidadJugadoresValida()
                && PresupuestoValido();
        }

        public decimal PuntajeFecha(byte fecha, List<Puntuacion> puntuaciones)
        {
            if (fecha == 0 || fecha >= 50)
            {
                throw new ArgumentOutOfRangeException(nameof(fecha), "La fecha debe ser menor a 50 y mayor a 0.");
            }

            if (puntuaciones == null)
            {
                throw new ArgumentNullException(nameof(puntuaciones));
            }

            decimal puntajeTotal = 0m;

            foreach (Puntuacion puntuacion in puntuaciones)
            {
                if (puntuacion.Fecha != fecha)
                    continue;

                foreach (Jugador jugador in _titulares)
                {
                    if (jugador.Id == puntuacion.IdJugador)
                    {
                        puntajeTotal += puntuacion.Puntaje;
                        break;
                    }
                }
            }

            return puntajeTotal;
        }

        private void AgregarJugador(Jugador jugador, List<Jugador> destino)
        {
            if (jugador == null)
            {
                throw new ArgumentNullException(nameof(jugador));
            }
            if (_titulares.Count + _suplentes.Count >= CantidadMaximaJugadores)
            {
                throw new InvalidOperationException("La plantilla alcanzó la cantidad máxima de jugadores.");
            }
            foreach (Jugador jugadorActual in _titulares)
            {
                if (jugadorActual.Id == jugador.Id)
                    throw new InvalidOperationException("Un jugador no puede repetirse en una plantilla.");
            }

            foreach (Jugador jugadorActual in _suplentes)
            {
                if (jugadorActual.Id == jugador.Id)
                    throw new InvalidOperationException("Un jugador no puede repetirse en una plantilla.");
            }

            destino.Add(jugador);
        }
    }
}