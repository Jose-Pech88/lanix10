
namespace ReadFile.Services.Interfaces
{
    public interface IObtenedorConfiguracionTiempo
    {
        /// <summary>
        /// Obtiene el valor configurado para minutos.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        int ObtenerMinutosMinuto();

        /// <summary>
        /// Obtiene el valor en minutos de una hora.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        int ObtenerMinutosHora();

        /// <summary>
        /// Obtiene el valor en minutos de una día.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        int ObtenerMinutosDia();

        /// <summary>
        /// Obtiene el valor en minutos de un mes.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        int ObtenerMinutosMes();
    }
}
