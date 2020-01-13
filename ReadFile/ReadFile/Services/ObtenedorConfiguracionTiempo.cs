using ReadFile.Services.Interfaces;

namespace ReadFile.Services
{
    public class ObtenedorConfiguracionTiempo : IObtenedorConfiguracionTiempo
    {
        /// <summary>
        /// Obtiene el valor configurado para minutos.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        public int ObtenerMinutosMinuto()
        {
            return 1;
        }

        /// <summary>
        /// Obtiene el valor en minutos de una hora.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        public int ObtenerMinutosHora()
        {
            return (ObtenerMinutosMinuto() * 60);
        }

        /// <summary>
        /// Obtiene el valor en minutos de una día.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        public int ObtenerMinutosDia()
        {
            return (ObtenerMinutosHora() * 24);
        }

        /// <summary>
        /// Obtiene el valor en minutos de un mes.
        /// </summary>
        /// <returns>Retorna un entero que contiene los minutos.</returns>
        public int ObtenerMinutosMes()
        {
            return (ObtenerMinutosDia() * 30);
        }
    }
}
