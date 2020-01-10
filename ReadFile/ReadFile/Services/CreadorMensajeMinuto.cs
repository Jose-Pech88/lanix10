using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services
{
    public class CreadorMensajeMinuto : ICreadorMensaje
    {
        private readonly IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo;
        public CreadorMensajeMinuto(IObtenedorConfiguracionTiempo _obtenedorConfiguracionTiempo)
        {
            ObtenedorConfiguracionTiempo = _obtenedorConfiguracionTiempo ?? throw new ArgumentNullException(nameof(_obtenedorConfiguracionTiempo));
        }

        public string CrearMensajeOcurrido(string _cEvento, int _iTiempoTranscurrido)
        {
            return string.Format("{0} ocurrió hace {1} minutos", _cEvento, ObtenerValorTiempo(_iTiempoTranscurrido));
        }

        public string CrearMensajePorOcurrir(string _cEvento, int _iTiempoPorTranscurrir)
        {
            return string.Format("{0} ocurrirá dentro de {1} minutos", _cEvento, ObtenerValorTiempo(_iTiempoPorTranscurrir));
        }

        private int ObtenerValorTiempo(int _iTiempo)
        {
            return (int)(_iTiempo / ObtenedorConfiguracionTiempo.ObtenerMinutosMinuto());
        }
    }
}
