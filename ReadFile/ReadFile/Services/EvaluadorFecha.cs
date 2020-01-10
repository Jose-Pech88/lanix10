using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services
{
    public class EvaluadorFecha : IEvaluadorFecha
    {
        private readonly IObtenedorConfiguracionTiempo ObtenedorConfiguracionTiempo;
        public EvaluadorFecha(IObtenedorConfiguracionTiempo _obtenedorConfiguracionTiempo)
        {
            ObtenedorConfiguracionTiempo = _obtenedorConfiguracionTiempo ?? throw new ArgumentNullException(nameof(_obtenedorConfiguracionTiempo));
        }
        public bool EvaluarFechaEventoPasado(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            return _dtFechaEvaluar.CompareTo(_dtFechaBase) < 0 ? true : false;
        }

        public int EvaluarFecha(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            int iOpcion = -1;
            double dMinutos = ObtenerTiempoEnMinutos(_dtFechaBase, _dtFechaEvaluar);
            if (dMinutos >= ObtenedorConfiguracionTiempo.ObtenerMinutosMes())
            {
                iOpcion = 3;
            }
            else
            {
                if (dMinutos >= ObtenedorConfiguracionTiempo.ObtenerMinutosDia())
                {
                    iOpcion = 2;
                }
                else
                {
                    if (dMinutos >= ObtenedorConfiguracionTiempo.ObtenerMinutosHora())
                    {
                        iOpcion = 1;
                    }
                    else
                    {
                        iOpcion = 0;
                    }
                }
            }
            return iOpcion;
        }

        public double ObtenerTiempoEnMinutos(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            return Math.Abs((_dtFechaEvaluar - _dtFechaBase).TotalMinutes);
        }
    }
}
