﻿using ReadFile.Data.Entities;
using System.Collections.Generic;

namespace ReadFile.Services.Interfaces
{
    /// <summary>
    /// Crea una lista de objetos EventoDTO con las información contenida en el archivo cuya ubicación es enviada como parámetro.
    /// </summary>
    /// <param name="_path">Ruta del archivo a procesar.</param>
    /// <returns>Retorna una lista de objetos de tipo EventoDTO.</returns>
    public interface IRecuperadorListaEvento
    {
        List<EventoDTO> RecuperarListaEvento(string _path);
    }
}
