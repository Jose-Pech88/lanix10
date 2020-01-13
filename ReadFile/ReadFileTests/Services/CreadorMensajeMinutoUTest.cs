using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Services;
using ReadFile.Services.Interfaces;

namespace ReadFileTests.Services
{
    [TestClass]
    public class CreadorMensajeMinutoUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new CreadorMensajeMinuto(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void CrearMensajeOcurrido_ValidarMensajeEvento_CadenaConMensaje()
        {
            //Arrange
            string cEvento = "Evento X";
            var DOCObtenedorConfiguracionTiempo = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracionTiempo.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            var SUT = new CreadorMensajeMinuto(DOCObtenedorConfiguracionTiempo.Object);

            //Act
            string cMensaje = SUT.CrearMensajeOcurrido(cEvento, 50);

            //Assert
            Assert.AreEqual("Evento X ocurrió hace 50 minutos", cMensaje);
        }

        [TestMethod]
        public void CrearMensajePorOcurrir_ValidarMensajeEvento_CadenaConMensaje()
        {
            //Arrange
            string cEvento = "Evento X";
            var DOCObtenedorConfiguracionTiempo = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracionTiempo.Setup((s) => s.ObtenerMinutosMinuto()).Returns(1);
            var SUT = new CreadorMensajeMinuto(DOCObtenedorConfiguracionTiempo.Object);

            //Act
            string cMensaje = SUT.CrearMensajePorOcurrir(cEvento, 50);

            //Assert
            Assert.AreEqual("Evento X ocurrirá dentro de 50 minutos", cMensaje);
        }
    }
}
