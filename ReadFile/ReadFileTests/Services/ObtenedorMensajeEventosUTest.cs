using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Services;
using ReadFile.Services.Interfaces;
using ReadFile.Services.Factory.Interfaces;
using ReadFile.Data.Entities;

namespace ReadFileUTest.Services
{
    /// <summary>
    /// Descripción resumida de ObtenedorMensajeEventosUTest
    /// </summary>
    [TestClass]
    public class ObtenedorMensajeEventosUTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajeEventos_CrearInstanciaDepenciaRecupadororListaEventoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            var DOCCreadorMensaje = new Mock<ICreadorMensajeFactory>();
            var DOCEvaluadorFecha = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(null, DOCCreadorMensaje.Object, DOCEvaluadorFecha.Object);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajeEventos_CrearInstanciaCreadorMensajeFactoryNulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            var DOCCreadorMensaje = new Mock<ICreadorMensajeFactory>();
            var DOCEvaluadorFecha = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, null, DOCEvaluadorFecha.Object);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajeEventos_CrearInstanciaCompletadorDatosDTONulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            var DOCCreadorMensaje = new Mock<ICreadorMensajeFactory>();
            var DOCEvaluadorFecha = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensaje.Object, null);
            //Act

            //Assert
        }

        [TestMethod]
        public void ObtenerMensaje_ListaEventoVacia_CadenaVacia()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05);
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensajeFactory>();
            var DOCEvaluadorFecha = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensaje.Object, DOCEvaluadorFecha.Object);
            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, string.Empty);
        }

        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnMinutosFuturo_CadenaConMensajeFuturo()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10,55,000);
            int iOpcion = 0;
            int iTiempoMinutos = 10;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Futuro";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = false };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajePorOcurrir(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrirá en {1} minutos", cEvento, iTiempoMinutos));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Futuro ocurrirá en 10 minutos\r\n");
        }


        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnMinutosPasado_CadenaConMensajePasado()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 45, 000);
            int iOpcion = 0;
            int iTiempoMinutos = 10;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Pasado";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = true };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajeOcurrido(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrió en {1} minutos", cEvento, iTiempoMinutos));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Pasado ocurrió en 10 minutos\r\n");
        }

        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnHorasFuturo_CadenaConMensajeFuturo()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 12, 45, 000);
            int iOpcion = 1;
            int iTiempoMinutos = 120;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Futuro";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = false };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajePorOcurrir(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrirá en {1} horas", cEvento, 2));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Futuro ocurrirá en 2 horas\r\n");
        }


        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnHorasPasado_CadenaConMensajePasado()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 12, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 55, 000);
            int iOpcion = 1;
            int iTiempoMinutos = 120;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Pasado";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = true };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajeOcurrido(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrió en {1} horas", cEvento, 2));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Pasado ocurrió en 2 horas\r\n");
        }

        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnDiasFuturo_CadenaConMensajeFuturo()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 07, 10, 45, 000);
            int iOpcion = 0;
            int iTiempoMinutos = 2880;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Futuro";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = false };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajePorOcurrir(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrirá en {1} días", cEvento, 2));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Futuro ocurrirá en 2 días\r\n");
        }


        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnDiasPasado_CadenaConMensajePasado()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 10, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 55, 000);
            int iOpcion = 0;
            int iTiempoMinutos = 2880;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Futuro";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = true };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajeOcurrido(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrió en {1} días", cEvento, 2));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Futuro ocurrió en 2 días\r\n");
        }

        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnMesesFuturo_CadenaConMensajeFuturo()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 00, 00, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 03, 05, 00, 00, 000);
            int iOpcion = 3;
            int iTiempoMinutos = 86400;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Futuro";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = false };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajePorOcurrir(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrirá en {1} meses", cEvento, 2));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Futuro ocurrirá en 2 meses\r\n");
        }
        
        [TestMethod]
        public void ObtenerMensaje_ListaEventoConItemEnMesesPasado_CadenaConMensajePasado()
        {
            //Arrange
            string cMensaje = string.Empty;
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 03, 05, 00, 00, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 00, 00, 000);
            int iOpcion = 3;
            int iTiempoMinutos = 86400;
            List<EventoDTO> lstEventoDTO = new List<EventoDTO>();
            string cEvento = "Evento Futuro";
            EventoDTO EventoDTO = new EventoDTO() { cEvento = cEvento, dtFecha = dtFechaEvaluar, iTiempoMinutos = iTiempoMinutos, iTipoMensaje = iOpcion, lEsEventoPasado = true };
            lstEventoDTO.Add(EventoDTO);
            var DOCCreadorMensaje = new Mock<ICreadorMensaje>();
            DOCCreadorMensaje.Setup((s) => s.CrearMensajeOcurrido(cEvento, iTiempoMinutos)).Returns(string.Format("{0} ocurrió en {1} meses", cEvento, 2));
            var DOCListaEvento = new Mock<IRecuperadorListaEvento>();
            DOCListaEvento.Setup((s) => s.RecuperarListaEvento(It.IsAny<string>())).Returns(lstEventoDTO);
            var DOCCreadorMensajeFactory = new Mock<ICreadorMensajeFactory>();
            DOCCreadorMensajeFactory.Setup((s) => s.ObtenerInstancia(iOpcion)).Returns(DOCCreadorMensaje.Object);
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var SUT = new ObtenedorMensajeEventos(DOCListaEvento.Object, DOCCreadorMensajeFactory.Object, DOCCompletadorDatosDTO.Object);

            //Act
            cMensaje = SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(cMensaje, "Evento Futuro ocurrió en 2 meses\r\n");
        }
    }
}
