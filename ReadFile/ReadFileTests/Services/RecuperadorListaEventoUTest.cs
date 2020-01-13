using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReadFile.Services.Interfaces;

namespace ReadFileTests.Services
{
    [TestClass]
    public class RecuperadorListaEventoUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RecuperadorListaEvento_ParametroIObtenedorDatosArchivoNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new RecuperadorListaEvento(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void RecuperarListaEvento_ArregloDatosVacio_ListaEventoVacia()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = null;
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaEvento(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaEvento(It.IsAny<string>());

            //Assert
            Assert.AreEqual(0, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaEvento_ArregloDatosConItem_ListaEventoCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Evento Navidad, 25/12/2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaEvento(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaEvento(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaEvento_ArregloDatosConItemSinSeparadorComa_ListaEventoCon1ItemConFechaMinima()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Evento Navidad" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaEvento(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaEvento(It.IsAny<string>());

            //Assert
            Assert.AreEqual(DateTime.MinValue, lstEvento[0].dtFecha);
        }
    }
}
