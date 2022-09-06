using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace AssemblyLevel
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Debug.WriteLine("Derleme başlangıç metodu çalıştı");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Debug.WriteLine("Derleme Temizleme metodu çalıştı");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("birim testi 1 : Sınıf Temizleme metodu çalıştı");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("birim testi 1 : Sınıf başlangıç metodu çalıştı");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("birim testi 1 : test metodu 1 çalıştı");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine("birim testi 1 : test metodu 2 çalıştı");
        }
    }
}
