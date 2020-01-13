using ReadFile.Services.Interfaces;
using System;

namespace ReadFile.Services
{
    public class RecuperadorTiempoEvento : IRecuperadorTiempoEvento
    {
        /// <summary>
        /// Recupera el tiempo de diferencia en minutos que existe entre dos fechas.
        /// </summary>
        /// <param name="_dtFechaBase">Fecha actual.</param>
        /// <param name="_dtFechaEvaluar">Fecha a evaluar.</param>
        /// <returns>Retorna un entero que indica la cantidad de minutos de diferencia.</returns>
        public int RecuperarTiempoEventoMinutos(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            return (int)Math.Abs((_dtFechaEvaluar - _dtFechaBase).TotalMinutes);
        }
    }
}
