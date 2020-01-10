using ReadFile.Services;
using ReadFile.Services.Factory;
using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                InicializarAplicacion();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            System.Console.ReadKey();
        }

        private static void InicializarAplicacion()
        {
            string cMensaje = string.Empty;
            IObtenedorMensajeEventosFactory ObtenedorMensajeEventosFactory = new ObtenedorMensajeEventosFactory();
            IObtenedorMensajeEventos ObtenedorMensajeEventos = ObtenedorMensajeEventosFactory.ObtenerInstancia();
            cMensaje = ObtenedorMensajeEventos.ObtenerMensaje(@"C:\Users\jose.pech\source\repos\ReadFile\ReadFile\Ffile.txt", DateTime.Now);
            Console.WriteLine(cMensaje);
        }
    }
}
