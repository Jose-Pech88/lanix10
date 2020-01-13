using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;

namespace ReadFile.Services.Factory
{
    public class CompletadorDatosDTOFactory : ICompletadorDatosDTOFactory
    {
        /// <summary>
        /// Crea una instancia de la clase CompletadorDatosDTO.
        /// </summary>
        /// <returns>Retorna una interfaz de tipo ICompletadorDatosDTO.</returns>
        public ICompletadorDatosDTO ObtenerInstancia()
        {
            IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo = new ObtenedorConfiguracionTiempo();
            IEvaluadorFechaAnterior EvaluadorFechaAnterior = new EvaluadorFechaAnterior();
            IRecuperadorEstrategiaMensajeEvento RecuperadorEstrategiaMensajeEvento = new RecuperadorEstrategiaMensajeEvento(ObtenedorConfiguracionTiempo);
            IRecuperadorTiempoEvento RecuperadorTiempoEvento = new RecuperadorTiempoEvento();
            return new CompletadorDatosDTO(EvaluadorFechaAnterior, RecuperadorEstrategiaMensajeEvento, RecuperadorTiempoEvento);
        }
    }
}
