using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Tests
{
    [TestClass()]
    public class CartManagerTests
    {
        
        [TestMethod()]
        public void Sepete_urun_eklene_bilmelidir()
        {
            // Arrange 
            const int beklenen = 1; // sepette ürün yok oyüzden ilk ekleme de beklenen

            var cartManager = new CartManager();
            var cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    UnitPrice= 3000
                },
                Quantity = 1
            };

            //Act
            cartManager.Ekle(cartItem);
            var toplamElemanSayısı = cartManager.ToplamUrun;

            //Assert
            Assert.AreEqual(beklenen, toplamElemanSayısı);
        }

        [TestMethod()]
        public void Seppette_olan_urun_cikarilabilmelidir()
        {
            // Arrange 
            var cartManager = new CartManager();
            var cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    UnitPrice = 3000
                },
                Quantity = 1
            };

            var beklenenElemanSayisi = cartManager.ToplamUrun;

            cartManager.Ekle(cartItem);

            //Act
            cartManager.Cikar(cartItem);
            var toplamElemanSayısı = cartManager.ToplamUrun;

            //Assert
            Assert.AreEqual(beklenenElemanSayisi, toplamElemanSayısı);
        }

        [TestMethod()]
        public void Sepet_temzilenebilmelidir()
        {
            // Arrange 
            const int beklenenEkle = 1;
            const int beklenen = 0;

            var cartManager = new CartManager();
            var cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    UnitPrice = 3000
                },
                Quantity = 1
            };

            //Act
            cartManager.Ekle(cartItem);
            var toplamElemanSayısı1 = cartManager.ToplamUrun;
            cartManager.temizle();
            var toplamElemanSayısı = cartManager.ToplamUrun;
            //Assert
            Assert.AreEqual(beklenenEkle, toplamElemanSayısı1);
            Assert.AreNotEqual(toplamElemanSayısı, toplamElemanSayısı1);
            Assert.AreEqual(beklenen, toplamElemanSayısı);
        }

    }
}