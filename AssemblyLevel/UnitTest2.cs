using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace AssemblyLevel
{
    [TestClass]
    public class UnitTest2
    {
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("birim testi 2 : Sınıf Temizleme metodu çalıştı");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("birim testi 2 : Sınıf başlangıç metodu çalıştı");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("birim testi 2 : test metodu 1 çalıştı");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine("birim testi 2 : test metodu 2 çalıştı");
        }
    }
}
