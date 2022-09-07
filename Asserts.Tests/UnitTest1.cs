using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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

        [TestMethod]
        public void TestMethodReferanslarEşitmi()
        {
            //Hazırlık
            Byte[] sayilar = new byte[] {1,2,3};

            //Eylem
            var diğerSayılar = sayilar;
            sayilar[0] = 4;

            Console.WriteLine(sayilar.convertString());
            Console.WriteLine(diğerSayılar.convertString());

            //Tez
            Assert.AreSame(sayilar, diğerSayılar); // referansları eşit
            //Assert.AreNotSame(sayilar, diğerSayılar, "İkisinide referansları eşittir");
        }
        
    }

    internal static class ExtensionMy {
        public static string convertString(this Byte[] bytes)
        {
            string result = "{ ";
            foreach(Byte b in bytes)
            {
                result += b.ToString() + " , ";
            }

            result=result.Substring(0, result.Length - 2);

            result += "}";

            return result;
        }
    }
        
}
