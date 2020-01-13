using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Services;
using ReadFile.Services.Interfaces;

namespace ReadFileTests.Services
{
    [TestClass]
    public class RecuperadorEstrategiaMensajeEventoUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RecuperadorEstrategiaMensajeEvento_ParametroIObtenedorConfiguracionTiempoNullo_ArgumentNullException()
        {
            //Arrange
            var SUT = new RecuperadorEstrategiaMensajeEvento(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnPasado_EstrategiaMinuto()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 55, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(0, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnFuturo_EstrategiaMinuto()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 45, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(0, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnPasado_EstrategiaHoras()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 14, 55, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(1, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnFuturo_EstrategiaHoras()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 20, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 14, 45, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(1, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnPasado_EstrategiaDias()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 08, 10, 55, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(2, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnFuturo_EstrategiaDias()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 08, 10, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 45, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(2, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnPasado_EstrategiaMes()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 03, 05, 10, 55, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(3, Estrategia);
        }

        [TestMethod]
        public void RecuperarEstrategiaMensajeEvento_FechaBaseEnFuturo_EstrategiaMes()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 03, 05, 10, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 45, 000);
            var DOCObtenedorConfiguracion = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosDia()).Returns(1440);
            DOCObtenedorConfiguracion.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new RecuperadorEstrategiaMensajeEvento(DOCObtenedorConfiguracion.Object);

            //Act
            var Estrategia = SUT.RecuperarEstrategiaMensajeEvento(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(3, Estrategia);
        }
    }
}
