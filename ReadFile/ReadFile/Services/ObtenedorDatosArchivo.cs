using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services
{
    public class ObtenedorDatosArchivo: IObtenedorDatosArchivo
    {
        public ObtenedorDatosArchivo()
        {
        }

        public string[] LeerArchivo(string _path)
        {
            return System.IO.File.ReadAllLines(_path);
        }
    }
}
