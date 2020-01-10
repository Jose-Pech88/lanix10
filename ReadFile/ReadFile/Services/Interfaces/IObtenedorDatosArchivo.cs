using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Interfaces
{
    public interface IObtenedorDatosArchivo
    {
        string[] LeerArchivo(string _path);
    }
}
