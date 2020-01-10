using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Factory
{
    public class RecuperadorListaEventoFactory
    {
        public IRecuperadorListaEvento ObtenerInstancia()
        {
            IObtenedorDatosArchivo ObtenedorDatosArchivo = new ObtenedorDatosArchivo();
            return new RecuperadorListaEvento(ObtenedorDatosArchivo);
        }
    }
}
