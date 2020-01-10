using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Interfaces
{
    public interface ICreadorMensaje
    {
        string CrearMensajeOcurrido(string _cEvento, int _iTiempoTranscurrido);
        string CrearMensajePorOcurrir(string _cEvento, int _iTiempoPorTranscurrir);
    }
}
