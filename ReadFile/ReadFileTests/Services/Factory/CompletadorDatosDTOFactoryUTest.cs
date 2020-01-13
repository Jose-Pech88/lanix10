using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile.Services.Factory;
using ReadFile.Services;

namespace ReadFileUTest.Services.Factory
{
    [TestClass]
    public class CompletadorDatosDTOFactoryUTest
    {

        [TestMethod]
        public void ObtenerInstancia_CrearInstancia_NuevaInstanciaCompletadorDatosDTO()
        {
            //Arrange
            var SUT = new CompletadorDatosDTOFactory();

            //Act
            var CompletadorDatos = SUT.ObtenerInstancia();

            //Assert
            Assert.IsInstanceOfType(CompletadorDatos, typeof(CompletadorDatosDTO));
        }
    }
}
