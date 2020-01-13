using ReadFile.Data.Entities;
using System;
using System.Collections.Generic;

namespace ReadFile.Services.Interfaces
{
    public class RecuperadorListaEvento : IRecuperadorListaEvento
    {
        /// <summary>
        /// Dependencia de tipo IObtenedorDatosArchivo.
        /// </summary>
        private readonly IObtenedorDatosArchivo ObtenedorDatosArchivo;

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="_obtenedorDatosArchivo">Dependencia de tipo IObtenedorDatosArchivo</param>
        public RecuperadorListaEvento(IObtenedorDatosArchivo _obtenedorDatosArchivo)
        {
            ObtenedorDatosArchivo = _obtenedorDatosArchivo ?? throw new ArgumentNullException(nameof(_obtenedorDatosArchivo));
        }

        /// <summary>
        /// Crea una lista de objetos EventoDTO con las información contenida en el archivo cuya ubicación es enviada como parámetro.
        /// </summary>
        /// <param name="_path">Ruta del archivo a procesar.</param>
        /// <returns>Retorna una lista de objetos de tipo EventoDTO.</returns>
        public List<EventoDTO> RecuperarListaEvento(string _path)
        {
            List<EventoDTO> lstEventos = new List<EventoDTO>();
            string[] arrFilas = ObtenedorDatosArchivo.LeerArchivo(_path);
            if (arrFilas != null)
            {
                lstEventos = LlenarListaEventosConArregloDatos(arrFilas);
            }
            return lstEventos;
        }

        /// <summary>
        /// Llena la lista de EventoDTO con la información contenida en el objeto enviado como parámetro.
        /// </summary>
        /// <param name="_arreglo">Arreglo que contiene la información a procesar.</param>
        /// <returns>Retorna una lista de objetos EventoDTO.</returns>
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

        /// <summary>
        /// Separa una cadena cuando encuentra una Coma.
        /// </summary>
        /// <param name="_cadena">Texto a separar.</param>
        /// <returns>Retorna un arreglo con la información separada por coma.</returns>
        private string[] SepararValoresCadenaComa(string _cadena)
        {
            return _cadena.Split(',');
        }

        /// <summary>
        /// Crea un objeto de tipo EventoDTO y asigna los valores que recibe como parámetro.
        /// </summary>
        /// <param name="_arrValores">Arreglo que contien los valores a asignar al DTO.</param>
        /// <returns>Retorna un objeto de tipo EventoDTO.</returns>
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
