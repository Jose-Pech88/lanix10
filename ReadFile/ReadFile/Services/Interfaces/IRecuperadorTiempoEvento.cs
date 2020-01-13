using System;

namespace ReadFile.Services.Interfaces
{
    public interface IRecuperadorTiempoEvento
    {
        /// <summary>
        /// Recupera el tiempo de diferencia en minutos que existe entre dos fechas.
        /// </summary>
        /// <param name="_dtFechaBase">Fecha actual.</param>
        /// <param name="_dtFechaEvaluar">Fecha a evaluar.</param>
        /// <returns>Retorna un entero que indica la cantidad de minutos de diferencia.</returns>
        int RecuperarTiempoEventoMinutos(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);
    }
}