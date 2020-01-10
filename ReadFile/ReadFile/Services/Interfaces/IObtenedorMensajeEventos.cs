using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Interfaces
{
    public interface IObtenedorMensajeEventos
    {
        /// <summary>
        /// Obtiene el mensaje a mostrar.
        /// </summary>
        /// <param name="_path">Dirección física del archivo a leer.</param>
        /// <param name="_dtFechaBase">Fecha Base que servirá para comparar.</param>
        /// <returns>Retorna una cadena que contiene el mensaje a mostrar.</returns>
        string ObtenerMensaje(string _path, DateTime _dtFechaBase);
    }
}
