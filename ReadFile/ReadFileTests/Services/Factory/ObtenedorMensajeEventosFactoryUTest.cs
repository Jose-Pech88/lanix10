using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile.Services;
using ReadFile.Services.Factory;

namespace ReadFileUTest.Services.Factory
{
    [TestClass]
    public class ObtenedorMensajeEventosFactoryUTest
    {
        [TestMethod]
        public void ObtenerInstancia_CrearInstancia_NuevaInstanciaObtenedorMensajeEventos()
        {
            //Arrange
            var SUT = new ObtenedorMensajeEventosFactory();

            //Act
            var ObtenedorMensaje = SUT.ObtenerInstancia();

            //Assert
            Assert.IsInstanceOfType(ObtenedorMensaje, typeof(ObtenedorMensajeEventos));
        }
    }
}
