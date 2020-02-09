using System.Collections.Generic;
using System.Diagnostics;
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

        public int GetTotalPrice(List<Product> allowedProducts, GroupOffer storeGroupOffer)
        {
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

            AdjustCartForFreeOffers(allowedProducts, cart);

            var basketTotal = AdjustBasketTotalForGroupOffer(storeGroupOffer, cart);
            foreach (var sku in cart.Keys)
            {
                var currentSku = allowedProducts.First(p => p.Sku == sku);
                basketTotal += currentSku.GetPrice(cart[sku]);
            }

            return basketTotal;
        }

        private int AdjustBasketTotalForGroupOffer(GroupOffer storeGroupOffer, Dictionary<char, int> cart)
        {
            var basketTotal = 0;
            if (storeGroupOffer != null)
            {
                var groupOfferItems = 0;
                foreach (var offersku in storeGroupOffer.Skus)
                {
                    if (cart.ContainsKey(offersku))
                    {
                        groupOfferItems += cart[offersku];
                    }
                }

                if (groupOfferItems / storeGroupOffer.Count > 0)
                {
                    basketTotal = (groupOfferItems / storeGroupOffer.Count) * storeGroupOffer.SpecialPrice;
                    groupOfferItems = (groupOfferItems / storeGroupOffer.Count) * storeGroupOffer.Count;

                    foreach (var offersku in storeGroupOffer.Skus)
                    {
                        while (groupOfferItems > 0 && cart.ContainsKey(offersku) && cart[offersku] > 0)
                        {
                            cart[offersku]--;
                            groupOfferItems--;
                        }
                    }
                }
            }

            return basketTotal;
        }

        private void AdjustCartForFreeOffers(List<Product> allowedProducts, Dictionary<char, int> cart)
        {
            for (var skuCount = 0; skuCount < cart.Keys.Count; skuCount++)
            {
                var sku = cart.Keys.ElementAt(skuCount);
                var currentSku = allowedProducts.First(p => p.Sku == sku);
                if (currentSku.FreeOffer != null)
                {
                    foreach (var offer in currentSku.FreeOffer)
                    {
                        var neededCount = CalculateSkuCountNeededToGetThisOffer(offer, sku);
                        var itemsInThisOffer = cart[sku] / neededCount;
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
        }

        private int CalculateSkuCountNeededToGetThisOffer(FreeProductOffer offer, char sku)
        {
            var neededCount = offer.Count;
            if (sku == offer.FreeSku)
            {
                neededCount++;
            }

            return neededCount;
        }
    }
}