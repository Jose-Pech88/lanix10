using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile.Services;
using ReadFile.Services.Factory;

namespace ReadFileUTest.Services.Factory
{
    [TestClass()]
    public class CreadorMensajeFactoryUTest
    {
        [TestMethod()]
        public void ObtenerInstanciaTest_ObtenerInstacia_InstanciaNula()
        {
            //Arrange
            int iOpcion = -1;
            var SUT = new CreadorMensajeFactory();

            //Act
            var CreadorMensaje = SUT.ObtenerInstancia(iOpcion);

            //Assert
            Assert.IsNull(CreadorMensaje);
        }

        [TestMethod()]
        public void ObtenerInstanciaTest_ObtenerInstacia_InstanciaCrearMensajeMinuto()
        {
            //Arrange
            int iOpcion = 0;
            var SUT = new CreadorMensajeFactory();

            //Act
            var CreadorMensaje = SUT.ObtenerInstancia(iOpcion);

            //Assert
            Assert.IsInstanceOfType(CreadorMensaje, typeof(CreadorMensajeMinuto));
        }

        [TestMethod()]
        public void ObtenerInstanciaTest_ObtenerInstacia_InstanciaCrearMensajeHora()
        {
            //Arrange
            int iOpcion = 1;
            var SUT = new CreadorMensajeFactory();

            //Act
            var CreadorMensaje = SUT.ObtenerInstancia(iOpcion);

            //Assert
            Assert.IsInstanceOfType(CreadorMensaje, typeof(CreadorMensajeHora));
        }

        [TestMethod()]
        public void ObtenerInstanciaTest_ObtenerInstacia_InstanciaCrearMensajeDia()
        {
            //Arrange
            int iOpcion = 2;
            var SUT = new CreadorMensajeFactory();

            //Act
            var CreadorMensaje = SUT.ObtenerInstancia(iOpcion);

            //Assert
            Assert.IsInstanceOfType(CreadorMensaje, typeof(CreadorMensajeDia));
        }

        [TestMethod()]
        public void ObtenerInstanciaTest_ObtenerInstacia_InstanciaCrearMensajeMes()
        {
            //Arrange
            int iOpcion = 3;
            var SUT = new CreadorMensajeFactory();

            //Act
            var CreadorMensaje = SUT.ObtenerInstancia(iOpcion);

            //Assert
            Assert.IsInstanceOfType(CreadorMensaje, typeof(CreadorMensajeMes));
        }
    }
}