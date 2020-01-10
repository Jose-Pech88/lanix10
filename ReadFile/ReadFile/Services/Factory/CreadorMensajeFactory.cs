using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Factory
{
    public class CreadorMensajeFactory : ICreadorMensajeFactory
    {
        public ICreadorMensaje ObtenerInstancia(int _nOpcion)
        {
            IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo = new ObtenedorConfiguracionTiempo();
            ICreadorMensaje ICreadorMensaje = null;
            switch(_nOpcion)
            {
                case 0:
                    ICreadorMensaje = new CreadorMensajeMinuto(ObtenedorConfiguracionTiempo);
                    break;
                case 1:
                    ICreadorMensaje = new CreadorMensajeHora(ObtenedorConfiguracionTiempo);
                    break;
                case 2:
                    ICreadorMensaje = new CreadorMensajeDia(ObtenedorConfiguracionTiempo);
                    break;
                case 3:
                    ICreadorMensaje = new CreadorMensajeMes(ObtenedorConfiguracionTiempo);
                    break;
            }
            return ICreadorMensaje;
        }
    }
}
