using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;

namespace ReadFile.Services.Factory
{
    public class ObtenedorMensajeEventosFactory: IObtenedorMensajeEventosFactory
    {
        /// <summary>
        /// Crea una instancia de la clase ObtenedorMensajeEventos.
        /// </summary>
        /// <returns>Retorna una interfaz de tipo IObtenedorMensajeEventos.</returns>
        public IObtenedorMensajeEventos ObtenerInstancia()
        {
            IRecuperadorListaEventoFactory RecuperadorListaEventoFactory = new RecuperadorListaEventoFactory();
            ICreadorMensajeFactory CreadorMensajeFactory = new CreadorMensajeFactory();
            ICompletadorDatosDTOFactory CompletadorDatosDTOFactory = new CompletadorDatosDTOFactory();
            IRecuperadorListaEvento RecuperadorListaEvento = RecuperadorListaEventoFactory.ObtenerInstancia();
            ICompletadorDatosDTO CompletadorDatos = CompletadorDatosDTOFactory.ObtenerInstancia();
            IObtenedorMensajeEventos ObtenedorMensajeEventos = new ObtenedorMensajeEventos(RecuperadorListaEvento, CreadorMensajeFactory, CompletadorDatos);
            return ObtenedorMensajeEventos;
        }
    }
}
