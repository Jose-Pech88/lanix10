using ReadFile.Services.Interfaces;
using System;

namespace ReadFile.Services
{
    public class CreadorMensajeHora : ICreadorMensaje
    {
        /// <summary>
        /// Dependencia de tipo IObtenedorConfiguracionTiempo.
        /// </summary>
        private readonly IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo;

        /// <summary>
        /// Contructor de la clase.
        /// </summary>
        /// <param name="_obtenedorConfiguracionTiempo">Dependencia de tipo IObtenedorConfiguracionTiempo.</param>
        public CreadorMensajeHora(IObtenedorConfiguracionTiempo _obtenedorConfiguracionTiempo)
        {
            ObtenedorConfiguracionTiempo = _obtenedorConfiguracionTiempo ?? throw new ArgumentNullException(nameof(_obtenedorConfiguracionTiempo));
        }

        /// <summary>
        /// Crea un mensaje cuando el evento ya ocurrio.
        /// </summary>
        /// <param name="_cEvento">Cadena que contiene el nombre del evento.</param>
        /// <param name="_iTiempoTranscurrido">Tiempo trancurrido en minutos</param>
        /// <returns>Retorna una cadena que contiene el mensaje.</returns>
        public string CrearMensajeOcurrido(string _cEvento, int _iTiempoTranscurrido)
        {
            return string.Format("{0} ocurrió hace {1} horas", _cEvento, ObtenerValorTiempo(_iTiempoTranscurrido));
        }

        /// <summary>
        /// Crea un mensaje cuando el evento esta por ocurrir.
        /// </summary>
        /// <param name="_cEvento">Cadena que contiene el nombre del evento.</param>
        /// <param name="_iTiempoTranscurrido">Tiempo trancurrido en minutos</param>
        /// <returns>Retorna una cadena que contiene el mensaje.</returns>
        public string CrearMensajePorOcurrir(string _cEvento, int _iTiempoPorTranscurrir)
        {
            return string.Format("{0} ocurrirá dentro de {1} horas", _cEvento, ObtenerValorTiempo(_iTiempoPorTranscurrir));
        }


        /// <summary>
        /// Obtiene el valor del tiempo en horas.
        /// </summary>
        /// <param name="_iTiempo">Cantidad de minutos.</param>
        /// <returns>Retorna un entero que contiene la cantidad de horas.</returns>
        private int ObtenerValorTiempo(int _iTiempo)
        {
            return (int)(_iTiempo / ObtenedorConfiguracionTiempo.ObtenerMinutosHora());
        }
    }
}
