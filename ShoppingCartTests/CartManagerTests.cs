using ShoppingCart;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Tests
{
    [TestClass()]
    public class CartManagerTests
    {
        static CartManager cartManager;
        static CartItem cartItem;

        [ClassInitialize]
        public static void KurulumClass(TestContext testContext)
        {
            cartManager = new CartManager();
            cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    UnitPrice = 3000
                },
                Quantity = 1
            };
        }

        [ClassCleanup]
        public static void BitimClass()
        {
            cartManager.temizle();
        }

        //[TestMethod]
        //public void Sepete_urun_eklene_bilmelidir()
        //{
        //    Arrange
        //    int beklenen = cartManager.ToplamUrun + 1;

        //    Act
        //    cartManager.Ekle(cartItem);
        //    var toplamElemanSayısı = cartManager.ToplamUrun;

        //    Assert
        //    Assert.AreEqual(beklenen, toplamElemanSayısı);
        //}


        //[TestMethod]
        //public void Seppette_olan_urun_cikarilabilmelidir()
        //{
        //    Arrange

        //   var beklenenElemanSayisi = cartManager.ToplamUrun;

        //    cartManager.Ekle(cartItem);

        //    Act
        //    cartManager.Cikar(cartItem);
        //    var toplamElemanSayısı = cartManager.ToplamUrun;

        //    Assert
        //    Assert.AreEqual(beklenenElemanSayisi, toplamElemanSayısı);
        //}

        //[TestMethod]
        //public void Sepet_temzilenebilmelidir()
        //{
        //    Arrange
        //    int beklenenEkle = cartManager.ToplamUrun + 1;
        //    const int beklenen = 0;

        //    Act
        //    cartManager.Ekle(cartItem);
        //    var toplamElemanSayısı1 = cartManager.ToplamUrun;
        //    cartManager.temizle();
        //    var toplamElemanSayısı = cartManager.ToplamUrun;
        //    Assert
        //    Assert.AreEqual(beklenenEkle, toplamElemanSayısı1);
        //    Assert.AreNotEqual(toplamElemanSayısı, toplamElemanSayısı1);
        //    Assert.AreEqual(beklenen, toplamElemanSayısı);
        //}

        [TestMethod]
        public void Sepete_ayni_urun_eklendgğinde_urun_cesidi_ayni_kalirken_toplam_urun_sayisi_artmali()
        {
            // Arrange
            cartManager.Ekle(cartItem);
            int toplamUrun;
            int beklenenToplamUrun = cartManager.ToplamUrun + 1;
            int toplamUrunCesidi;
            int beklenenUrunCesidi = cartManager.ToplamUrunCesidi;
            // Act
            cartManager.Ekle(cartItem);
            toplamUrun = cartManager.ToplamUrun;
            toplamUrunCesidi = cartManager.ToplamUrunCesidi;
            // Assert
            Assert.AreEqual(beklenenToplamUrun, toplamUrun);
            Assert.AreEqual(beklenenUrunCesidi, toplamUrunCesidi);
        }


        [TestMethod]
        public void Sepete_farkli_urun_eklendiginde_urun_cesidi_ve_toplam_urun_miktari_artmali()
        {
            // Arrange
            cartManager.Ekle(cartItem);
            int toplamUrun;
            int beklenenToplamUrun = cartManager.ToplamUrun + 1;
            int toplamUrunCesidi;
            int beklenenUrunCesidi = cartManager.ToplamUrunCesidi + 1;

            // Act
            cartManager.Ekle(
                new CartItem
                {
                    Product = new Product
                    {
                        Id = 2,
                        Name = "Fare",
                        UnitPrice = 100
                    },
                    Quantity = 1,
                });
            toplamUrun = cartManager.ToplamUrun;
            toplamUrunCesidi = cartManager.ToplamUrunCesidi;
            // Assert
            Assert.AreEqual(beklenenToplamUrun, toplamUrun);
            Assert.AreEqual(beklenenUrunCesidi, toplamUrunCesidi);
        }

    }
}