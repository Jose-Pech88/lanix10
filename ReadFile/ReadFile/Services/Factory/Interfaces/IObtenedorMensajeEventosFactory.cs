using ReadFile.Services.Interfaces;
namespace ReadFile.Services.Factory.Interfaces
{
    public interface IObtenedorMensajeEventosFactory
    {
        /// <summary>
        /// Crea una instancia de la clase ObtenedorMensajeEventos.
        /// </summary>
        /// <returns>Retorna una interfaz de tipo IObtenedorMensajeEventos.</returns>
        IObtenedorMensajeEventos ObtenerInstancia();
    }
}
