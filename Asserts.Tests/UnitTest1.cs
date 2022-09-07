using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            Byte[] sayilar = new byte[] { 1, 2, 3 };

            //Eylem
            var diğerSayılar = sayilar;
            sayilar[0] = 4;

            Console.WriteLine(sayilar.convertString());
            Console.WriteLine(diğerSayılar.convertString());

            //Tez
            Assert.AreSame(sayilar, diğerSayılar); // referansları eşit
            //Assert.AreNotSame(sayilar, diğerSayılar, "İkisinide referansları eşittir");
        }

        [TestMethod]
        public void TestMethodBaşarılıLakinYeterliDeğil()
        {
            Assert.AreEqual(1, 1); //Eşit olduğu için test başarılı bunun yerine kendi tezleriniz.
            Assert.Inconclusive("Bu test artık yerli değildir.");
        }

        [TestMethod]
        public void VeriBeliritlenTipteMi()
        {
            //Hazırlık
            var sayı = 5m;

            //Bilgilendirme
            Console.WriteLine("Sayı: " + sayı);

            //Tez
            Assert.IsInstanceOfType(sayı, typeof(decimal));
            Assert.IsNotInstanceOfType(sayı, typeof(int));
        }

        [TestMethod]
        public void DoğruMuVeyaYanlışMı()
        {
            Assert.IsTrue(10 % 2 == 0);
            Assert.IsFalse(10 % 2 == 1);
        }



        List<String> _kulanıcılar = new List<string>(new string[] { "Engin",
            "Salih",
            "Ahmet" });

        [TestMethod]
        public void SırasıAynıVeDeğerleriEşitMi()
        {
            //Hazırlık
            List<string> yeniKullanıcılar = new List<string>();

            //Eylem

            yeniKullanıcılar.Add("Engin");
            yeniKullanıcılar.Add("Salih");
            yeniKullanıcılar.Add("Ahmet");

            /*
            yeniKullanıcılar.Add("Engin");
            yeniKullanıcılar.Add("Ahmet");
            yeniKullanıcılar.Add("Salih");
            */

            //Tez
            //CollectionAssert.AreNotEqual(_kulanıcılar, yeniKullanıcılar,"Sıraları veya değerleri eşit");
            CollectionAssert.AreEqual(_kulanıcılar, yeniKullanıcılar, "Sıraları veya değerleri eşit değil");

        }

        [TestMethod]
        public void DeğerleriEşitMi()
        {
            //Hazırlık
            List<string> yeniKullanıcılar = new List<string>();

            //Eylem

            yeniKullanıcılar.Add("Engin");
            yeniKullanıcılar.Add("Ahmet");
            yeniKullanıcılar.Add("Salih");


            //Tez
            CollectionAssert.AreEquivalent(_kulanıcılar, yeniKullanıcılar, "Değerleri eşit değil");

        }

    }

    internal static class ExtensionMy
    {
        public static string convertString(this Byte[] bytes)
        {
            string result = "{ ";
            foreach (Byte b in bytes)
            {
                result += b.ToString() + " , ";
            }

            result = result.Substring(0, result.Length - 2);

            result += "}";

            return result;
        }
    }

}
