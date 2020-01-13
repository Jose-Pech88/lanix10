
namespace ReadFile.Services.Interfaces
{
    public interface ICreadorMensaje
    {
        /// <summary>
        /// Crea un mensaje cuando el evento ya ocurrio.
        /// </summary>
        /// <param name="_cEvento">Cadena que contiene el nombre del evento.</param>
        /// <param name="_iTiempoTranscurrido">Tiempo trancurrido en minutos</param>
        /// <returns>Retorna una cadena que contiene el mensaje.</returns>
        string CrearMensajeOcurrido(string _cEvento, int _iTiempoTranscurrido);

        /// <summary>
        /// Crea un mensaje cuando el evento esta por ocurrir.
        /// </summary>
        /// <param name="_cEvento">Cadena que contiene el nombre del evento.</param>
        /// <param name="_iTiempoTranscurrido">Tiempo trancurrido en minutos</param>
        /// <returns>Retorna una cadena que contiene el mensaje.</returns>
        string CrearMensajePorOcurrir(string _cEvento, int _iTiempoPorTranscurrir);
    }
}
