using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Factory
{
    public class ObtenedorMensajeEventosFactory: IObtenedorMensajeEventosFactory
    {
        public IObtenedorMensajeEventos ObtenerInstancia()
        {
            RecuperadorListaEventoFactory RecuperadorListaEventoFactory = new RecuperadorListaEventoFactory();
            CreadorMensajeFactory CreadorMensajeFactory = new CreadorMensajeFactory();
            EvaluadorFechaFactory EvaluadorFechaFactory = new EvaluadorFechaFactory();
            IRecuperadorListaEvento RecuperadorListaEvento = RecuperadorListaEventoFactory.ObtenerInstancia();
            IEvaluadorFecha EvaluadorFecha = EvaluadorFechaFactory.ObtenerInstancia();
            ObtenedorMensajeEventos ObtenedorMensajeEventos = new ObtenedorMensajeEventos(RecuperadorListaEvento, CreadorMensajeFactory, EvaluadorFecha);
            return ObtenedorMensajeEventos;
        }
    }
}
