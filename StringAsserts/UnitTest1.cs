using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace StringAsserts
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void İçerisindeVarMı()
        {
            //Hazırlık
            var icinde_mi = "Test dünyasında merhaba.";
            var arama_ifadesi = "yas";
            var arama_ifadesi2 = "Yas";

            //Tez
            StringAssert.Contains(icinde_mi, arama_ifadesi); //büyük küçük harf duyarlıdır
            //StringAssert.Contains(icinde_mi, arama_ifadesi2,"büyük küçük harf duyarlı");
        }

        [TestMethod]
        public void KalıbaUygunMu()
        {
            //Hazırlık
            var kontrol_edilecek = " Test methodu ilgili kalıba uygunmu? Sizce ;)";
            var uygun_kalıp = new Regex(@"[a-zA-Z]");
            var uygun_olmayan_kalıp = new Regex(@"[0-9]");

            //Tez
            StringAssert.Matches(kontrol_edilecek, uygun_kalıp);
            StringAssert.DoesNotMatch(kontrol_edilecek, uygun_olmayan_kalıp);
        }

        [TestMethod]
        public void İleMiBaşlıyor()
        {
            //Hazırlık
            var kontrol_edilecek = " Test methodu ilgili kalıba uygunmu? Sizce ;)";
            var baslangıc = " Test";

            //Tez
            StringAssert.StartsWith(kontrol_edilecek, baslangıc);
        }

        [TestMethod]
        public void İleMiBitiyor()
        {
            //Hazırlık
            var kontrol_edilecek = " Test methodu ilgili kalıba uygunmu? Sizce ;)";
            var bitis = "Sizce ;)";

            //Tez
            StringAssert.EndsWith(kontrol_edilecek, bitis);
        }
    }
}
