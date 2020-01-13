using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Services;
using ReadFile.Services.Interfaces;

namespace ReadFileTests.Services
{
    [TestClass]
    public class CreadorMensajeHoraUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new CreadorMensajeHora(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void CrearMensajeOcurrido_ValidarMensajeEvento_CadenaConMensaje()
        {
            //Arrange
            string cEvento = "Evento X";
            var DOCObtenedorConfiguracionTiempo = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracionTiempo.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            var SUT = new CreadorMensajeHora(DOCObtenedorConfiguracionTiempo.Object);

            //Act
            string cMensaje = SUT.CrearMensajeOcurrido(cEvento, 120);

            //Assert
            Assert.AreEqual("Evento X ocurrió hace 2 horas", cMensaje);
        }

        [TestMethod]
        public void CrearMensajePorOcurrir_ValidarMensajeEvento_CadenaConMensaje()
        {
            //Arrange
            string cEvento = "Evento X";
            var DOCObtenedorConfiguracionTiempo = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracionTiempo.Setup((s) => s.ObtenerMinutosHora()).Returns(60);
            var SUT = new CreadorMensajeHora(DOCObtenedorConfiguracionTiempo.Object);

            //Act
            string cMensaje = SUT.CrearMensajePorOcurrir(cEvento, 120);

            //Assert
            Assert.AreEqual("Evento X ocurrirá dentro de 2 horas", cMensaje);
        }
    }   
}
