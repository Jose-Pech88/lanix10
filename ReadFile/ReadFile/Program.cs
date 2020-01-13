using ReadFile.Services;
using ReadFile.Services.Factory;
using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;
using System;
using System.IO;

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
        }

        /// <summary>
        /// Inicializa la aplicación.
        /// </summary>
        private static void InicializarAplicacion()
        {
            string cMensaje = string.Empty;

            //Se obtiene la ruta del archivo.
            string cPath = string.Format("{0}{1}", Directory.GetCurrentDirectory(), @"\AppData\Ffile.txt");
            IObtenedorMensajeEventosFactory ObtenedorMensajeEventosFactory = new ObtenedorMensajeEventosFactory();
            IObtenedorMensajeEventos ObtenedorMensajeEventos = ObtenedorMensajeEventosFactory.ObtenerInstancia();
            cMensaje = ObtenedorMensajeEventos.ObtenerMensaje(cPath, DateTime.Now);
            Console.WriteLine(cMensaje);
            Console.WriteLine("\r\nPresione una tecla para salir.");
            System.Console.ReadKey();
        }
    }
}
