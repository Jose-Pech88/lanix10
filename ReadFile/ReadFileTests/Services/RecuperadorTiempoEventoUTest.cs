using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile.Services;

namespace ReadFileTests.Services
{
    [TestClass]
    public class RecuperadorTiempoEventoUTest
    {
        [TestMethod]
        public void RecuperarTiempoEventoMinutos_FechaBasePasado_TiempoMinutosPositivo()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 45, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 55, 000);
            var SUT = new RecuperadorTiempoEvento();

            //Act
            var nTiempo = SUT.RecuperarTiempoEventoMinutos(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(nTiempo, 10);
        }

        [TestMethod]
        public void RecuperarTiempoEventoMinutos_FechaBaseFuturo_TiempoMinutosPositivo()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 10, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 10, 45, 000);
            var SUT = new RecuperadorTiempoEvento();

            //Act
            var nTiempo = SUT.RecuperarTiempoEventoMinutos(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(nTiempo, 10);
        }
    }
}
