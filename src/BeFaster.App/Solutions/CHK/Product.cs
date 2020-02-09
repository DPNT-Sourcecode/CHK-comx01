using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public class Product
    {
        public char Sku { get; }
        public int Price { get; }
        public ProductOffer Offer { get; }

        public Product(char sku, int price, ProductOffer offer)
        {
            this.Sku = sku;
            this.Price = price;
            this.Offer = offer;
        }

        public int GetPrice(string skus)
        {
            var totalPrice = 0;
            var totalItemsOfThisSku = skus.Count(s => s == Sku);

            if (Offer != null && totalItemsOfThisSku / Offer.Count > 0)
            {
                return (totalItemsOfThisSku / Offer.Count * Offer.SpecialPrice) +
                       (totalItemsOfThisSku % Offer.Count) * Price;
            }

            return totalItemsOfThisSku * Price;
        }
    }
}
