using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Asserts.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodMesaj() //test resultta hata mesajı verme
        {
            //Arrange
            const double girilendeger = 16;
            const double beklenen = 4;
            //Act
            double gerceklesen = Math.Sqrt(girilendeger);
            //Assert
            Assert.AreEqual(beklenen, gerceklesen, $"{girilendeger} syısının karekökü {beklenen} olmalıdır.");
        }

        [TestMethod]
        public void TestMethodDelta()
        {
            //Hazırlık
            const double beklenen = 3.1622;
            const double delta = 0.0001;//Formül: |beklenen-gerçekleşen|<=delta
            //Eylem
            double gerceklesen = Math.Sqrt(10);
            //Tez
            Assert.AreEqual(beklenen, gerceklesen, delta);
        }

        [TestMethod]
        public void TestMethodBüyükKüçükHarfeDuyarsız()
        {
            //Ayar
            string belenen = "MERHABA", gerçekleşen = "merhaba";

            //Tez
            Assert.AreEqual(belenen, gerçekleşen, true);
        }

        [TestMethod]
        public void TestMethodEsitDegilse()
        {
            //Hazırlık
            const double beklenmeyen = 0;
            double gerçekleşen = Math.Pow(5, 0);

            //Tez
            Assert.AreNotEqual(beklenmeyen, gerçekleşen);

        }

    }
}
