using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;

namespace ReadFile.Services.Factory
{
    public class CreadorMensajeFactory : ICreadorMensajeFactory
    {
        /// <summary>
        /// Crea una instancia de una clase, dependiendo de la estrategia enviada como parámetro.
        /// </summary>
        /// <param name="_nOpcion">Estrategia que defina la instancia de la clase a crear.</param>
        /// <returns>Retorna una interfaz de tipo ICreadorMensaje.</returns>
        public ICreadorMensaje ObtenerInstancia(int _nOpcion)
        {
            IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo = new ObtenedorConfiguracionTiempo();
            ICreadorMensaje CreadorMensaje = null;
            switch(_nOpcion)
            {
                case 0:
                    CreadorMensaje = new CreadorMensajeMinuto(ObtenedorConfiguracionTiempo);
                    break;
                case 1:
                    CreadorMensaje = new CreadorMensajeHora(ObtenedorConfiguracionTiempo);
                    break;
                case 2:
                    CreadorMensaje = new CreadorMensajeDia(ObtenedorConfiguracionTiempo);
                    break;
                case 3:
                    CreadorMensaje = new CreadorMensajeMes(ObtenedorConfiguracionTiempo);
                    break;
            }
            return CreadorMensaje;
        }
    }
}
