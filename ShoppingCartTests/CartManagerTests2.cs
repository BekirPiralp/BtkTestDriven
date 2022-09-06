using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestClass]
    public class CartManagerTests2
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

            cartManager.OzelEkle(cartItem);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // sana bu tipte hata gelecek diyoruz ve gelirse test başarılı
        public void Sepete_Ayni_Urun_Ikinci_Defa_Ekelenemez_OzelEkle()
        {
            cartManager.OzelEkle(cartItem);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),AllowDerivedTypes =true)] //kalıtım ile gelen özellikler devreye alındı
        public void Sepete_Ayni_Urun_Ikinci_Defa_Ekelenemez_OzelEkle2()
        {
            cartManager.OzelEkle(cartItem);
        }
    }
}
