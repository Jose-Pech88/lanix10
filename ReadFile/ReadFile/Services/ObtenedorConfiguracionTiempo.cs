using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services
{
    public class ObtenedorConfiguracionTiempo : IObtenedorConfiguracionTiempo
    {
        public ObtenedorConfiguracionTiempo()
        {
        }

        public int ObtenerMinutosMinuto()
        {
            return 1;
        }

        public int ObtenerMinutosDia()
        {
            return (ObtenerMinutosHora() * 24);
        }

        public int ObtenerMinutosHora()
        {
            return (ObtenerMinutosMinuto() * 60);
        }

        public int ObtenerMinutosMes()
        {
            return (ObtenerMinutosDia() * 30);
        }
    }
}
