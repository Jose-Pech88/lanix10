using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Services;
using ReadFile.Services.Interfaces;

namespace ReadFileTests.Services
{
    [TestClass]
    public class CreadorMensajeMesUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new CreadorMensajeMes(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void CrearMensajeOcurrido_ValidarMensajeEvento_CadenaConMensaje()
        {
            //Arrange
            string cEvento = "Evento X";
            var DOCObtenedorConfiguracionTiempo = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracionTiempo.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new CreadorMensajeMes(DOCObtenedorConfiguracionTiempo.Object);

            //Act
            string cMensaje = SUT.CrearMensajeOcurrido(cEvento, 100000);

            //Assert
            Assert.AreEqual("Evento X ocurrió hace 2 meses", cMensaje);
        }

        [TestMethod]
        public void CrearMensajePorOcurrir_ValidarMensajeEvento_CadenaConMensaje()
        {
            //Arrange
            string cEvento = "Evento X";
            var DOCObtenedorConfiguracionTiempo = new Mock<IObtenedorConfiguracionTiempo>();
            DOCObtenedorConfiguracionTiempo.Setup((s) => s.ObtenerMinutosMes()).Returns(43200);
            var SUT = new CreadorMensajeMes(DOCObtenedorConfiguracionTiempo.Object);

            //Act
            string cMensaje = SUT.CrearMensajePorOcurrir(cEvento, 100000);

            //Assert
            Assert.AreEqual("Evento X ocurrirá dentro de 2 meses", cMensaje);
        }
    }
}
