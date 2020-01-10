using ReadFile.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services.Interfaces
{
    public class RecuperadorListaEvento : IRecuperadorListaEvento
    {
        private readonly IObtenedorDatosArchivo ObtenedorDatosArchivo;
        public RecuperadorListaEvento(IObtenedorDatosArchivo _obtenedorDatosArchivo)
        {
            ObtenedorDatosArchivo = _obtenedorDatosArchivo ?? throw new ArgumentNullException(nameof(_obtenedorDatosArchivo));
        }

        public List<EventoDTO> RecuperarListaEvento(string _path)
        {
            string[] arrFilas = ObtenedorDatosArchivo.LeerArchivo(_path);
            return LlenarListaEventosConArregloDatos(arrFilas);
        }

        private List<EventoDTO> LlenarListaEventosConArregloDatos(string[] _arreglo)
        {
            List<EventoDTO> lstEventos = new List<EventoDTO>();
            foreach (string item in _arreglo)
            {
                string[] arrValores = SepararValoresCadenaComa(item);
                EventoDTO evento = AsignarValoresEvento(arrValores);
                lstEventos.Add(evento);
            }
            return lstEventos;
        }

        private string[] SepararValoresCadenaComa(string _cadena)
        {
            return _cadena.Split(',');
        }
        private EventoDTO AsignarValoresEvento(string [] _arrValores)
        {
            EventoDTO evento = new EventoDTO();
            switch (_arrValores.Length)
            {
                case 1:
                    evento.cEvento = _arrValores[0];
                    break;
                case 2:
                    evento.cEvento = _arrValores[0];
                    evento.dtFecha = Convert.ToDateTime(_arrValores[1]);
                    break;
                default:
                    break;
            }
            return evento;
        }
    }
}
