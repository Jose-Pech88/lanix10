using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Interfaces
{
    public interface IEvaluadorFecha
    {
        bool EvaluarFechaEventoPasado(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);

        int EvaluarFecha(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);

        double ObtenerTiempoEnMinutos(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);
    }
}
