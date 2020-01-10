using ReadFile.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Interfaces
{
    public interface IRecuperadorListaEvento
    {
        List<EventoDTO> RecuperarListaEvento(string _pathFile);
    }
}
