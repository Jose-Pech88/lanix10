using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile.Services;

namespace ReadFileTests.Services
{
    [TestClass]
    public class ObtenedorConfiguracionTiempoUTest
    {
        [TestMethod]
        public void ObtenerMinutosMinuto_ObtenerValorMinuto_ValorConfiguracionMinuto()
        {
            //Arrange
            var SUT = new ObtenedorConfiguracionTiempo();

            //Act
            var Minutos = SUT.ObtenerMinutosMinuto();

            //Assert
            Assert.AreEqual(1, Minutos);
        }

        [TestMethod]
        public void ObtenerMinutosHora_ObtenerValorHora_ValorConfiguracionHora()
        {
            //Arrange
            var SUT = new ObtenedorConfiguracionTiempo();

            //Act
            var Minutos = SUT.ObtenerMinutosHora();

            //Assert
            Assert.AreEqual(60, Minutos);
        }

        [TestMethod]
        public void ObtenerMinutosDia_ObtenerValorDia_ValorConfiguracionMinutoParaDia()
        {
            //Arrange
            var SUT = new ObtenedorConfiguracionTiempo();

            //Act
            var Minutos = SUT.ObtenerMinutosDia();

            //Assert
            Assert.AreEqual(1440, Minutos);
        }

        [TestMethod]
        public void ObtenerMinutosMes_ObtenerValorMinuto_ValorConfiguracionMinutoParaMes()
        {
            //Arrange
            var SUT = new ObtenedorConfiguracionTiempo();

            //Act
            var Minutos = SUT.ObtenerMinutosMes();

            //Assert
            Assert.AreEqual(43200, Minutos);
        }
    }
}
