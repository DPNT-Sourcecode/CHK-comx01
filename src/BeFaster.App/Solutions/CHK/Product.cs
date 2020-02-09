using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public class Product
    {
        public char Sku { get; }
        public int Price { get; }
        public List<SpecialPriceOffer> Offer { get; }
        public List<FreeProductOffer> FreeOffer { get; }

        public Product(char sku, int price, List<SpecialPriceOffer> offer = null, List<FreeProductOffer> freeOffer = null)
        {
            this.Sku = sku;
            this.Price = price;
            this.Offer = offer;
            this.FreeOffer = freeOffer;
        }

        public int GetPrice(int itemsWithThisSku)
        {
            var totalPrice = 0;
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
