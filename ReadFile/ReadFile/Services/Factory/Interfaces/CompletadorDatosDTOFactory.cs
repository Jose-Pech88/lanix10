using ReadFile.Services.Interfaces;

namespace ReadFile.Services.Factory.Interfaces
{
    public interface ICompletadorDatosDTOFactory
    {
        /// <summary>
        /// Crea una instancia de la clase CompletadorDatosDTO.
        /// </summary>
        /// <returns>Retorna una interfaz de tipo ICompletadorDatosDTO.</returns>
        ICompletadorDatosDTO ObtenerInstancia();
    }
}
