using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile.Services.Factory;
using ReadFile.Services.Interfaces;

namespace ReadFileUTest.Services.Factory
{
    [TestClass]
    public class RecuperadorListaEventoFactoryUTest
    {
        [TestMethod]
        public void ObtenerInstancia_CrearInstancia_NuevaInstanciaRecuperadorListaEvento()
        {
            //Arrange
            var SUT = new RecuperadorListaEventoFactory();

            //Act
            var RecuperadorLista = SUT.ObtenerInstancia();

            //Assert
            Assert.IsInstanceOfType(RecuperadorLista, typeof(RecuperadorListaEvento));
        }
    }
}
