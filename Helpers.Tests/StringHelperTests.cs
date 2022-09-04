using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Helpers.Tests
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void Girilen_ifadenin_basindaki_ve_sonundaki_fazla_bosluklar_silinmelidir()
        {
            //Arrange
            var ifade = "   Bekir Piralp   ";
            var beklenen = "Bekir Piralp";

            //Act
            var gerceklesen = StringHelper.FazlaBosluklariSil(ifade);

            //Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }

        [TestMethod]
        public void Girilen_ifadenin_icerisindeki_fazla_bosluklar_silinmelidir()
        {
            //Arrange
            var ifade = "Bekir      Piralp  Adana    Konya   Selcuk Üni";
            var beklenen = "Bekir Piralp Adana Konya Selcuk Üni";

            //Act
            var gerceklesen = StringHelper.FazlaBosluklariSil(ifade);

            //Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }
    }
}
