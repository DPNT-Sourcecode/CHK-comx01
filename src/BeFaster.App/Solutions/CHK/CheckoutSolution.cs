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
            if (store.IsCartEmpty(skus) || store.HasInvalidProduct(skus))
            {
                return -1;
            }

            var basketTotal = 0;
            for (var skuCount = 0; skuCount < skus.Length; skuCount++)
            {
                var currentSku = store.ProductsInStore.First(p => p.Sku == skus[skuCount]);
                basketTotal += currentSku.Price;
            }

            return basketTotal;
        }
    }

    public class Store
    {
        public List<Product> ProductsInStore { get; set; }

        public Store()
        {
            ProductsInStore = new List<Product>()
            {
                new Product('A', 50),
                new Product('B', 30),
                new Product('C', 20),
                new Product('D', 15)
            };
        }

        public bool IsCartEmpty(string skus)
        {
            return string.IsNullOrWhiteSpace(skus);
        }

        public bool HasInvalidProduct(string skus)
        {
            for (var skuCount = 0; skuCount < skus.Length; skuCount++)
            {
                var currentSku = ProductsInStore.FirstOrDefault(p => p.Sku == skus[skuCount]);
                if (currentSku == null)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Product
    {
        public char Sku { get; private set; }
        public int Price { get; private set; }

        public Product(char sku, int price)
        {
            this.Sku = sku;
            this.Price = price;
        }
    }
}



