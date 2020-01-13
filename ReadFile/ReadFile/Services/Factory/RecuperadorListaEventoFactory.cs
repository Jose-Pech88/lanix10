using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;

namespace ReadFile.Services.Factory
{
    public class RecuperadorListaEventoFactory : IRecuperadorListaEventoFactory
    {
        /// <summary>
        /// Crea una instancia de la clase RecuperadorListaEvento.
        /// </summary>
        /// <returns>Retorna una interfaz de tipo IRecuperadorListaEvento.</returns>
        public IRecuperadorListaEvento ObtenerInstancia()
        {
            IObtenedorDatosArchivo ObtenedorDatosArchivo = new ObtenedorDatosArchivo();
            return new RecuperadorListaEvento(ObtenedorDatosArchivo);
        }
    }
}
