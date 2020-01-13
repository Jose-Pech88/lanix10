using ReadFile.Data.Entities;
using ReadFile.Services.Interfaces;
using System;

namespace ReadFile.Services
{
    public class RecuperadorEstrategiaMensajeEvento : IRecuperadorEstrategiaMensajeEvento
    {
        /// <summary>
        /// Dependencia de tipo IObtenedorConfiguracionTiempo.
        /// </summary>
        private readonly IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo;

        /// <summary>
        /// Contructor de la clase.
        /// </summary>
        /// <param name="_obtenedorConfiguracionTiempo">Dependencia de tipo IObtenedorConfiguracionTiempo.</param>
        public RecuperadorEstrategiaMensajeEvento(IObtenedorConfiguracionTiempo _obtenedorConfiguracionTiempo)
        {
            ObtenedorConfiguracionTiempo = _obtenedorConfiguracionTiempo ?? throw new ArgumentNullException(nameof(_obtenedorConfiguracionTiempo));
        }

        /// <summary>
        /// Método que obtiene la estrategia a utilizar para obtener el mensaje.
        /// </summary>
        /// <param name="_dtFechaBase">Fecha actual.</param>
        /// <param name="_dtFechaEvaluar">Fecha a Evaluar.</param>
        /// <returns>Retorna un entero que representa el tipo de estrategia a utilizar.</returns>
        public int RecuperarEstrategiaMensajeEvento(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            int iOpcion = -1;
            double dMinutos = ObtenerTiempoEnMinutos(_dtFechaBase, _dtFechaEvaluar);
            if (dMinutos >= ObtenedorConfiguracionTiempo.ObtenerMinutosMes())
            {
                iOpcion = 3;
            }
            else
            {
                if (dMinutos >= ObtenedorConfiguracionTiempo.ObtenerMinutosDia())
                {
                    iOpcion = 2;
                }
                else
                {
                    if (dMinutos >= ObtenedorConfiguracionTiempo.ObtenerMinutosHora())
                    {
                        iOpcion = 1;
                    }
                    else
                    {
                        iOpcion = 0;
                    }
                }
            }
            return iOpcion;
        }

        /// <summary>
        /// Obtiene la diferencia en minutos que existe entre dos fechas
        /// </summary>
        /// <param name="_dtFechaBase">Fecha actual.</param>
        /// <param name="_dtFechaEvaluar">Fecha a Evaluar.</param>
        /// <returns>Retorna la diferencia en minutos.</returns>
        private double ObtenerTiempoEnMinutos(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            return Math.Abs((_dtFechaEvaluar - _dtFechaBase).TotalMinutes);
        }

    }
}
