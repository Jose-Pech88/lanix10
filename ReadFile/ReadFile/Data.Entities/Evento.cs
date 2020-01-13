using System;

namespace ReadFile.Data.Entities
{
    public class EventoDTO
    {
        /// <summary>
        /// Indica el nombre del evento.
        /// </summary>
        public string cEvento { get; set; }

        /// <summary>
        /// Indica la fecha del evento.
        /// </summary>
        public DateTime dtFecha { get; set; }

        /// <summary>
        /// Indica si el evento ya ocurrio o no.
        /// </summary>
        public bool lEsEventoPasado { get; set; }

        /// <summary>
        /// Tiempo transcurrido en minutos del evento.
        /// </summary>
        public int iTiempoMinutos { get; set; }

        /// <summary>
        /// Estrategia a utilizar para obtener el mensaje.
        /// </summary>
        public int iTipoMensaje { get; set; }
    }
}
