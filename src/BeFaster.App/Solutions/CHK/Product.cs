using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public class Product
    {
        public char Sku { get; }
        public int Price { get; }
        public List<ProductOffer> Offer { get; }

        public Product(char sku, int price, List<ProductOffer> offer)
        {
            this.Sku = sku;
            this.Price = price;
            this.Offer = offer;
        }

        public int GetPrice(string skus)
        {
            var totalPrice = 0;
            var itemsWithThisSku = skus.Count(s => s == Sku);

            if (Offer != null)
            {
                var orderedOffers = Offer.OrderByDescending(o => o.Count);
                foreach (var offer in orderedOffers)
                {
                    var itemsInThisOffer = itemsWithThisSku / offer.Count;
                    if (itemsInThisOffer > 0)
                    {
                        totalPrice += (itemsInThisOffer * offer.SpecialPrice);
                    }

                    itemsWithThisSku -= (itemsInThisOffer * offer.Count);
                }
            }

            totalPrice += itemsWithThisSku * Price;

            return totalPrice;
        }
    }
}

