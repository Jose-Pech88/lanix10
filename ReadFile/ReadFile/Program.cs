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
            string[] rows = System.IO.File.ReadAllLines(@"C:\Users\jose.pech\source\repos\ReadFile\ReadFile\Ffile.txt");
            int iContador = 1;
            string cMensaje = string.Empty;
            string cEvento = string.Empty;
            string cFecha = string.Empty;
            string cMensajeFechaEvento = string.Empty;
            foreach (string cCadena in rows)
            {
                string[] cols=cCadena.Split(',');
                
                if (cols.Length > 1)
                {
                    cEvento = cols[0];
                    cFecha = cols[1];
                    DateTime dtFecha = Convert.ToDateTime(cFecha);
                    cMensajeFechaEvento = MensajeTiempoDelEvento(dtFecha);
                    if (EventoPasado(dtFecha))
                    {
                        cMensaje = string.Format("{0} ocurrió hace {1}", cEvento, cMensajeFechaEvento);
                    }
                    else
                    {
                        cMensaje = string.Format("{0} ocurrirá dentro de {1}", cEvento, cMensajeFechaEvento);
                    }
                }
                else {
                    cMensaje = string.Format("No se pudo determinar la fecha en la linea {0}", iContador);
                }
                
                Console.WriteLine(cMensaje);
                iContador++;                
            }
            System.Console.ReadKey();
        }

        private static bool EventoPasado(DateTime _dtFechaEvento)
        {
            return _dtFechaEvento.CompareTo(DateTime.Now) < 0 ? true : false;
        }

        private static string MensajeTiempoDelEvento(DateTime _dtFechaEvento)
        {
            string cMensaje = string.Empty;
            DateTime dtHoy = DateTime.Now;
            double dDias = Math.Abs((_dtFechaEvento - dtHoy).TotalDays);
            if (dDias > 30)
            {
                //Mes
                dDias = (dDias / 30);
                cMensaje = string.Format("{0} Meses", (int)dDias);
            }
            else 
            {
                //Dias
                if (dDias < 1)
                {
                    double dHoras = Math.Abs((_dtFechaEvento - dtHoy).TotalHours);
                    if (dHoras < 1)
                    {
                        double dMinutos = Math.Abs((_dtFechaEvento - dtHoy).TotalMinutes);
                        cMensaje = string.Format("{0} Minutos", (int)dMinutos);
                    }
                    else
                    {

                        cMensaje = string.Format("{0} Horas", (int)dHoras);
                    }
                }
                else
                {
                    cMensaje = string.Format("{0} días", (int)dDias);
                }
            }
            return cMensaje;
        }
    }
}
