using ReadFile.Data.Entities;
using System;

namespace ReadFile.Services.Interfaces
{    public interface ICompletadorDatosDTO
    {
        /// <summary>
        /// Llena la propiedades del DTO.
        /// </summary>
        /// <param name="evento">Dto a llenar.</param>
        /// <param name="_dtFechaBase">Fecha base que servira para comparar.</param>
        void LlenarDTOEvento(EventoDTO _evento, DateTime dtFechaBase);
    }
}
