using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TextContextTests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        private String Anahtar = "bilgi";

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("-- Test Initialize --\n");
            TestContext.WriteLine("Test Adı:    \t{0}", TestContext.TestName);
            TestContext.WriteLine("Test Durumu: \t{0}", TestContext.CurrentTestOutcome);
            TestContext.Properties[Anahtar] = "Bu bir ekstra bilgidir.";
            TestContext.WriteLine("");
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestContext.WriteLine("\t-->> Test\n");
            TestContext.WriteLine("\tTest Adı:    \t{0}", TestContext.TestName);
            TestContext.WriteLine("\tTest Durumu: \t{0}", TestContext.CurrentTestOutcome);
            TestContext.WriteLine("\tTest Sınıfı: \t{0}", TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine("\tTest Dir:    \t{0}", TestContext.TestDir);
            TestContext.WriteLine("\tTest LogDir: \t{0}", TestContext.TestLogsDir);
            TestContext.WriteLine("\tTest RunDir: \t{0}", TestContext.TestRunDirectory);
            TestContext.WriteLine("\tTest Bilgi:  \t{0}", TestContext.Properties[Anahtar]);
            TestContext.WriteLine("");

            Assert.AreEqual(1, 1);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("-- Test Cleanup --\n");
            TestContext.WriteLine("Test Adı:    \t{0}", TestContext.TestName);
            TestContext.WriteLine("Test Durumu: \t{0}", TestContext.CurrentTestOutcome);
            TestContext.WriteLine("Test Bilgi:  \t{0}", TestContext.Properties[Anahtar]);
            TestContext.WriteLine("");
        }
    }
}
