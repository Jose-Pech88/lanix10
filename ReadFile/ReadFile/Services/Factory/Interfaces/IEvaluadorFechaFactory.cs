using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Factory.Interfaces
{
    public interface IEvaluadorFechaFactory
    {
        IEvaluadorFecha ObtenerInstancia();
    }
}
