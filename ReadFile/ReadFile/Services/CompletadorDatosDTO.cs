using ReadFile.Data.Entities;
using ReadFile.Services.Interfaces;
using System;

namespace ReadFile.Services
{
    public class CompletadorDatosDTO : ICompletadorDatosDTO
    {
        /// <summary>
        /// Dependencia de tipo IEvaluadorFechaAnterior.
        /// </summary>
        private readonly IEvaluadorFechaAnterior EvaluadorFechaAnterior;

        /// <summary>
        /// Dependencia de tipo IRecuperadorEstrategiaMensajeEvento.
        /// </summary>
        private readonly IRecuperadorEstrategiaMensajeEvento RecuperadorEstrategiaMensajeEvento;

        /// <summary>
        /// Dependencia de tipo IRecuperadorTiempoEvento.
        /// </summary>
        private readonly IRecuperadorTiempoEvento RecuperadorTiempoEvento;

        /// <summary>
        /// Contructor de la clase.
        /// </summary>
        /// <param name="_evaluadorFechaAnterior">Dependencia de tipo IEvaluadorFechaAnterior.</param>
        /// <param name="_recuperadorEstrategiaMensajeEvento">Dependencia de tipo IRecuperadorEstrategiaMensajeEvento.</param>
        /// <param name="_recuperadorTiempoEvento">Dependencia de tipo IRecuperadorTiempoEvento.</param>
        public CompletadorDatosDTO(IEvaluadorFechaAnterior _evaluadorFechaAnterior, IRecuperadorEstrategiaMensajeEvento _recuperadorEstrategiaMensajeEvento, IRecuperadorTiempoEvento _recuperadorTiempoEvento)
        {
            EvaluadorFechaAnterior = _evaluadorFechaAnterior ?? throw new ArgumentNullException(nameof(_evaluadorFechaAnterior));
            RecuperadorEstrategiaMensajeEvento = _recuperadorEstrategiaMensajeEvento ?? throw new ArgumentNullException(nameof(_recuperadorEstrategiaMensajeEvento));
            RecuperadorTiempoEvento = _recuperadorTiempoEvento ?? throw new ArgumentNullException(nameof(_recuperadorTiempoEvento));
        }

        /// <summary>
        /// Llena la propiedades del DTO.
        /// </summary>
        /// <param name="evento">Dto a llenar.</param>
        /// <param name="_dtFechaBase">Fecha base que servira para comparar.</param>
        public void LlenarDTOEvento(EventoDTO evento, DateTime _dtFechaBase)
        {
            if (evento == null)
                throw new ArgumentNullException(nameof(evento));
            evento.lEsEventoPasado = EvaluadorFechaAnterior.EvaluarFechaAnterior(_dtFechaBase, evento.dtFecha);
            evento.iTipoMensaje = RecuperadorEstrategiaMensajeEvento.RecuperarEstrategiaMensajeEvento(_dtFechaBase, evento.dtFecha);
            evento.iTiempoMinutos = RecuperadorTiempoEvento.RecuperarTiempoEventoMinutos(_dtFechaBase, evento.dtFecha);
        }
    }
}
