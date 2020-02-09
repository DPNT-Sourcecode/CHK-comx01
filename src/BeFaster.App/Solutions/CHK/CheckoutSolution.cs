using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var store = new Store();
            var cart = new Cart(skus);
            if (cart.IsEmpty() || cart.HasInvalidProduct(store.ProductsInStore))
            {
                return -1;
            }

            return cart.TotalPrice(store.ProductsInStore);
        }
    }

    public class Store
    {
        public List<Product> ProductsInStore { get; }

        public Store()
        {
            ProductsInStore = new List<Product>()
            {
                new Product('A', 50, new ProductOffer(3, 130)),
                new Product('B', 30, new ProductOffer(2, 45)),
                new Product('C', 20, null),
                new Product('D', 15, null)
            };
        }
    }

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

        public int TotalPrice(List<Product> allowedProducts)
        {
            var basketTotal = 0;
            var uniqueSkus = skus.Distinct().ToList();

            for (var skuCount = 0; skuCount < uniqueSkus.Count(); skuCount++)
            {
                var currentSku = allowedProducts.First(p => p.Sku == uniqueSkus[skuCount]);
                basketTotal += currentSku.GetPrice(skus);
            }

            return basketTotal;
        }
    }

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
            var totalItemsOfThisSku = skus.Select(s => s == Sku).Count();

            if (Offer != null && totalItemsOfThisSku / Offer.Count > 0)
            {
                return (totalItemsOfThisSku / Offer.Count * Offer.SpecialPrice) +
                    (totalItemsOfThisSku % Offer.Count) * Price;
            }

            return totalItemsOfThisSku * Price;
        }
    }

    public class ProductOffer
    {
        public int Count { get; }
        public int SpecialPrice { get; }

        public ProductOffer(int count, int specialPrice)
        {
            this.Count = count;
            this.SpecialPrice = specialPrice;
        }
    }
}


