using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Factory
{
    public class EvaluadorFechaFactory
    {
        public IEvaluadorFecha ObtenerInstancia()
        {
            IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo = new ObtenedorConfiguracionTiempo();
            return new EvaluadorFecha(ObtenedorConfiguracionTiempo);
        }
    }
}
