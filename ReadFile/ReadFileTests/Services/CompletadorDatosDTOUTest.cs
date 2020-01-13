using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Data.Entities;
using ReadFile.Services;
using ReadFile.Services.Interfaces;

namespace ReadFileTests.Services
{
    [TestClass]
    public class CompletadorDatosDTOUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorEstrategiaMensajeEvento = new Mock<IRecuperadorEstrategiaMensajeEvento>();
            var DOCRecuperadorTiempoEvento = new Mock<IRecuperadorTiempoEvento>();
            var SUT = new CompletadorDatosDTO(null, DOCRecuperadorEstrategiaMensajeEvento.Object, DOCRecuperadorTiempoEvento.Object);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIRecuperadorEstrategiaMensajeEventoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            var DOCRecuperadorTiempoEvento = new Mock<IRecuperadorTiempoEvento>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, null, DOCRecuperadorTiempoEvento.Object);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIRecuperadorTiempoEventoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            var DOCRecuperadorEstrategiaMensajeEvento = new Mock<IRecuperadorEstrategiaMensajeEvento>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorEstrategiaMensajeEvento.Object, null);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LlenarDTOEvento_ParametroEventoNulo_ArgumentNullException()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            var DOCRecuperadorEstrategiaMensajeEvento = new Mock<IRecuperadorEstrategiaMensajeEvento>();
            var DOCRecuperadorTiempoEvento = new Mock<IRecuperadorTiempoEvento>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorEstrategiaMensajeEvento.Object, DOCRecuperadorTiempoEvento.Object);

            //Act
            SUT.LlenarDTOEvento(null, dtFechaBase);

            //Assert

        }

        [TestMethod]
        public void LlenarDTOEvento_AsignarValorPropiedadEsEventoPasado_PropiedadEsEventoPasadoIgualATrue()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            EventoDTO Evento = new EventoDTO() { cEvento = "Evento X", dtFecha = new DateTime(2020, 01, 10, 20, 55, 000)};
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            DOCEvaluadorFechaAnterior.Setup((s) => s.EvaluarFechaAnterior(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            var DOCRecuperadorEstrategiaMensajeEvento = new Mock<IRecuperadorEstrategiaMensajeEvento>();
            var DOCRecuperadorTiempoEvento = new Mock<IRecuperadorTiempoEvento>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorEstrategiaMensajeEvento.Object, DOCRecuperadorTiempoEvento.Object);

            //Act
            SUT.LlenarDTOEvento(Evento, dtFechaBase);

            //Assert
            Assert.AreEqual(true, Evento.lEsEventoPasado);
        }

        [TestMethod]
        public void LlenarDTOEvento_AsignarValorPropiedadTipoMensaje_PropiedadTipoMensajeIgualA0()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            EventoDTO Evento = new EventoDTO() { cEvento = "Evento X", dtFecha = new DateTime(2020, 01, 10, 20, 55, 000) };
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            DOCEvaluadorFechaAnterior.Setup((s) => s.EvaluarFechaAnterior(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            var DOCRecuperadorEstrategiaMensajeEvento = new Mock<IRecuperadorEstrategiaMensajeEvento>();
            DOCRecuperadorEstrategiaMensajeEvento.Setup((s) => s.RecuperarEstrategiaMensajeEvento(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(1);
            var DOCRecuperadorTiempoEvento = new Mock<IRecuperadorTiempoEvento>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorEstrategiaMensajeEvento.Object, DOCRecuperadorTiempoEvento.Object);

            //Act
            SUT.LlenarDTOEvento(Evento, dtFechaBase);

            //Assert
            Assert.AreEqual(1, Evento.iTipoMensaje);
        }

        [TestMethod]
        public void LlenarDTOEvento_AsignarValorPropiedadTiempoMinutos_PropiedadTiempoMinutosIgualA10()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            EventoDTO Evento = new EventoDTO() { cEvento = "Evento X", dtFecha = new DateTime(2020, 01, 10, 20, 55, 000) };
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            DOCEvaluadorFechaAnterior.Setup((s) => s.EvaluarFechaAnterior(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            var DOCRecuperadorEstrategiaMensajeEvento = new Mock<IRecuperadorEstrategiaMensajeEvento>();
            DOCRecuperadorEstrategiaMensajeEvento.Setup((s) => s.RecuperarEstrategiaMensajeEvento(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(1);
            var DOCRecuperadorTiempoEvento = new Mock<IRecuperadorTiempoEvento>();
            DOCRecuperadorTiempoEvento.Setup((s) => s.RecuperarTiempoEventoMinutos(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(50);
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorEstrategiaMensajeEvento.Object, DOCRecuperadorTiempoEvento.Object);

            //Act
            SUT.LlenarDTOEvento(Evento, dtFechaBase);

            //Assert
            Assert.AreEqual(50, Evento.iTiempoMinutos);
        }
    }
}
