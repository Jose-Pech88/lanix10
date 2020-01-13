using ReadFile.Services.Interfaces;

namespace ReadFile.Services.Factory.Interfaces
{
    public interface ICreadorMensajeFactory
    {
        /// <summary>
        /// Crea una instancia de una clase, dependiendo de la estrategia enviada como parámetro.
        /// </summary>
        /// <param name="_nOpcion">Estrategia que defina la instancia de la clase a crear.</param>
        /// <returns>Retorna una interfaz de tipo ICreadorMensaje.</returns>
        ICreadorMensaje ObtenerInstancia(int _nOpcion);
    }
}
