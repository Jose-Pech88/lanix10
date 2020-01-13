using ReadFile.Data.Entities;
using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ReadFile.Services
{
    public class ObtenedorMensajeEventos : IObtenedorMensajeEventos
    {
        /// <summary>
        /// Dependencia de tipo IRecuperadorListaEvento.
        /// </summary>
        private readonly IRecuperadorListaEvento RecuperadorListaEvento;

        /// <summary>
        /// Dependencia de tipo ICreadorMensajeFactory.
        /// </summary>
        private readonly ICreadorMensajeFactory CreadorMensajeFactory;

        /// <summary>
        /// Dependencia de tipo IComplementadorDatosDTO.
        /// </summary>
        private readonly ICompletadorDatosDTO CompletadorDatosDTO;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="_recuperadorListaEvento">Dependencia de tipo IRecuperadorListaEvento.</param>
        /// <param name="_creadorMensajeFactory">Dependencia de tipo ICreadorMensajeFactory.</param>
        /// <param name="_completadorDatosDTO">Dependencia de tipo IComplementadorDatosDTO.</param>
        public ObtenedorMensajeEventos(IRecuperadorListaEvento _recuperadorListaEvento, ICreadorMensajeFactory _creadorMensajeFactory, ICompletadorDatosDTO _completadorDatosDTO)
        {
            RecuperadorListaEvento = _recuperadorListaEvento ?? throw new ArgumentNullException(nameof(_recuperadorListaEvento));
            CreadorMensajeFactory = _creadorMensajeFactory ?? throw new ArgumentNullException(nameof(_creadorMensajeFactory));
            CompletadorDatosDTO = _completadorDatosDTO ?? throw new ArgumentNullException(nameof(_completadorDatosDTO));
        }

        /// <summary>
        /// Obtiene el mensaje a mostrar.
        /// </summary>
        /// <param name="_path">Dirección física del archivo a leer.</param>
        /// <param name="_dtFechaBase">Fecha Base que servirá para comparar.</param>
        /// <returns>Retorna una cadena que contiene el mensaje a mostrar.</returns>
        public string ObtenerMensaje(string _path, DateTime _dtFechaBase)
        {
            List<EventoDTO> lstEventos = RecuperadorListaEvento.RecuperarListaEvento(_path);
            return ObtenerMensajeDeListaEventos(lstEventos, _dtFechaBase);
        }

        /// <summary>
        /// Obtiene el mensaje a mostrar de acuerdo a los registros contenidos en la lista de Evento.
        /// </summary>
        /// <param name="_lstEvento">Listo de objetos de objetos DTO´s</param>
        /// <param name="_dtFechaBase">Fecha Base que servira para comparar.</param>
        /// <returns>Retorna una cadena que contiene la concatenación de los mensajes de cada item de la lista.</returns>
        private string ObtenerMensajeDeListaEventos(List<EventoDTO> _lstEvento, DateTime _dtFechaBase)
        {
            string cMensajeEventos = string.Empty;
            string cMensaje = string.Empty;
            foreach(EventoDTO item in _lstEvento)
            {
                if(item.dtFecha!=DateTime.MinValue)
                {
                    CompletadorDatosDTO.LlenarDTOEvento(item, _dtFechaBase);
                    ICreadorMensaje ICreadorMensaje = CreadorMensajeFactory.ObtenerInstancia(item.iTipoMensaje);
                    if (item.lEsEventoPasado)
                    {
                        cMensaje = ICreadorMensaje.CrearMensajeOcurrido(item.cEvento, item.iTiempoMinutos);
                    }
                    else
                    {
                        cMensaje = ICreadorMensaje.CrearMensajePorOcurrir(item.cEvento, item.iTiempoMinutos);
                    }
                    cMensajeEventos = string.Format("{0}{1}\r\n", cMensajeEventos, cMensaje);
                }
            }
            return cMensajeEventos;
        }
    }
}
