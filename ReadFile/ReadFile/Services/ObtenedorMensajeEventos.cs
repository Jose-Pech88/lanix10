using ReadFile.Data.Entities;
using ReadFile.Services.Factory.Interfaces;
using ReadFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Services
{
    public class ObtenedorMensajeEventos : IObtenedorMensajeEventos
    {
        private readonly IRecuperadorListaEvento RecuperadorListaEvento;
        private readonly ICreadorMensajeFactory CreadorMensajeFactory;
        private readonly IEvaluadorFecha EvaluadorFecha;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="_recuperadorListaEvento">Dependencia de tipo IRecuperadorListaEvento.</param>
        /// <param name="_creadorMensajeFactory">Dependencia de tipo ICreadorMensajeFactory.</param>
        /// <param name="_evaluadorFecha">Dependencia de tipo IEvaluadorFecha.</param>
        public ObtenedorMensajeEventos(IRecuperadorListaEvento _recuperadorListaEvento, ICreadorMensajeFactory _creadorMensajeFactory, IEvaluadorFecha _evaluadorFecha)
        {
            RecuperadorListaEvento = _recuperadorListaEvento ?? throw new ArgumentNullException(nameof(_recuperadorListaEvento));
            CreadorMensajeFactory = _creadorMensajeFactory ?? throw new ArgumentNullException(nameof(_creadorMensajeFactory));
            EvaluadorFecha = _evaluadorFecha ?? throw new ArgumentNullException(nameof(_evaluadorFecha));
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
                    LlenarDTOEvento(item, _dtFechaBase);
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

        /// <summary>
        /// Llena la propiedades del DTO.
        /// </summary>
        /// <param name="evento">Dto a llenar.</param>
        /// <param name="_dtFechaBase">Fecha Base que servira para comparar.</param>
        private void LlenarDTOEvento(EventoDTO evento, DateTime _dtFechaBase)
        {
            evento.lEsEventoPasado = EvaluadorFecha.EvaluarFechaEventoPasado(_dtFechaBase, evento.dtFecha);
            evento.iTipoMensaje=EvaluadorFecha.EvaluarFecha(_dtFechaBase, evento.dtFecha);
            evento.iTiempoMinutos=(int)EvaluadorFecha.ObtenerTiempoEnMinutos(_dtFechaBase, evento.dtFecha);
        }
    }
}
