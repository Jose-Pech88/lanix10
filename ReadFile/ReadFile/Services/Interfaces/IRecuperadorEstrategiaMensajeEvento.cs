using System;

namespace ReadFile.Services.Interfaces
{
    public interface IRecuperadorEstrategiaMensajeEvento
    {
        /// <summary>
        /// Método que obtiene la estrategia a utilizar para obtener el mensaje.
        /// </summary>
        /// <param name="_dtFechaBase">Fecha actual.</param>
        /// <param name="_dtFechaEvaluar">Fecha a Evaluar.</param>
        /// <returns>Retorna un entero que representa el tipo de estrategia a utilizar.</returns>
        int RecuperarEstrategiaMensajeEvento(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);

    }
}
