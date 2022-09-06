using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    /**
     * Gereksinimler
     * 1. Sepete ürün eklene bilmelidir
     * 2. Seppette olan ürün çıkarılabilmelidir
     * 3. Sepet temzilenebilmelidir
     * 
     * 4. Sepete aynı ürün eklendiğinde ürün çeşidi aynı kalırken toplam ürün sayısı artmalı
     * 5. Sepete farklı ürün eklendiğinde ürün çeşidi ve toplam ürün miktarı artmalı
     * 
     * 6. Sepete aynı ürün ikincidefe ekelenemez ozelEkle metodu için
     */
    public class CartManager
    {
        private readonly List<CartItem> _sepet;

        public CartManager()
        {
            _sepet = new List<CartItem>();
        }

        public void Ekle(CartItem Urun)
        {
            if (Urun != null && Urun.Product != null)
            {
                if (Urun.Quantity <= 0)
                    Urun.Quantity = 1;

                var urunListe = _sepet.FirstOrDefault(i => i.Product.Id == Urun.Product.Id);
                if (urunListe != null)
                {
                    urunListe.Quantity += Urun.Quantity;
                }
                else
                {
                    _sepet.Add(Urun);
                }
            }

        }

        public void OzelEkle(CartItem Urun)
        {
            if (Urun != null && Urun.Product != null)
            {
                if (Urun.Quantity <= 0)
                    Urun.Quantity = 1;

                var urunListe = _sepet.FirstOrDefault(i => i.Product.Id == Urun.Product.Id);
                if (urunListe != null)
                {
                    throw new ArgumentException("Sepette aynı ürün bulunmaktadır.");
                }
                else
                {
                    _sepet.Add(Urun);
                }
            }
        }

        public void Cikar(CartItem Urun)
        {
            var urunSepet = _sepet.FirstOrDefault(i => i.Product.Id == Urun.Product.Id);
            if (urunSepet != null)
            {
                if (urunSepet.Quantity > Urun.Quantity && Urun.Quantity != 0)
                {
                    urunSepet.Quantity -= Urun.Quantity;
                }
                else if (urunSepet.Quantity <= Urun.Quantity)
                {
                    _sepet.Remove(urunSepet);
                }
                else
                {
                    urunSepet.Quantity--;
                    if (urunSepet.Quantity <= 0)
                        _sepet.Remove(urunSepet);
                }
            }
        }

        public void temizle()
        {
            _sepet.Clear();
        }

        public List<CartItem> Sepet
        {
            get
            {
                return _sepet;
            }
        }

        public int ToplamUrunCesidi
        {
            get
            {
                return _sepet.Count;
            }
        }

        public decimal ToplamFiyat
        {
            get
            {
                return _sepet.Sum(i => i.Quantity * i.Product.UnitPrice);
            }
        }

        public int ToplamUrun
        {
            get
            {
                return _sepet.Sum(i => i.Quantity);
            }
        }
    }
}
