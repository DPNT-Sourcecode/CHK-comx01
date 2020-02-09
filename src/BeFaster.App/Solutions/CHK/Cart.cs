using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public class Cart
    {
        public string skus { get; }

        public Cart(string skus)
        {
            this.skus = skus;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(skus);
        }

        public bool HasInvalidProduct(List<Product> allowedProducts)
        {
            for (var skuCount = 0; skuCount < skus.Length; skuCount++)
            {
                var currentSku = allowedProducts.FirstOrDefault(p => p.Sku == skus[skuCount]);
                if (currentSku == null)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetTotalPrice(List<Product> allowedProducts)
        {
            var basketTotal = 0;
            var cart = new Dictionary<char, int>();

            foreach (var sku in skus)
            {
                if (cart.ContainsKey(sku))
                {
                    cart[sku] += 1;
                }
                else
                {
                    cart.Add(sku, 1);
                }
                
            }

            foreach (var sku in cart.Keys)
            {
                var currentSku = allowedProducts.First(p => p.Sku == sku);
                if (currentSku.FreeOffer != null)
                {
                    foreach (var offer in currentSku.FreeOffer)
                    {
                        var itemsInThisOffer = cart[sku]/offer.Count;
                        if (itemsInThisOffer > 0 && cart.ContainsKey(offer.FreeSku))
                        {
                            cart[offer.FreeSku] -= itemsInThisOffer;
                            if (cart[offer.FreeSku] < 0)
                            {
                                cart[offer.FreeSku] = 0;
                            }
                        }
                    }
                }
            }

            foreach (var sku in cart.Keys)
            {
                var currentSku = allowedProducts.First(p => p.Sku == sku);
                basketTotal += currentSku.GetPrice(skus);
            }

            return basketTotal;
        }
    }
}
