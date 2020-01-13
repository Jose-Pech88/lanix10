using ReadFile.Services.Interfaces;
namespace ReadFile.Services.Factory.Interfaces
{
    public interface IRecuperadorListaEventoFactory
    {
        /// <summary>
        /// Crea una instancia de la clase RecuperadorListaEvento.
        /// </summary>
        /// <returns>Retorna una interfaz de tipo IRecuperadorListaEvento.</returns>
        IRecuperadorListaEvento ObtenerInstancia();
    }
}
