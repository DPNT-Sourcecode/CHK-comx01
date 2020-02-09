using System.Collections.Generic;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var productsInStore = InitialiseStore();

            var basketTotal = 0;
            for (var skuCount = 0; skuCount < skus.Length; skuCount++)
            {
                var currentSku = 

            }

            return basketTotal;
        }

        public static List<Product> InitialiseStore()
        {
            return 
        }
    }

    public class Store
    {
        public List<Product> ProductsInStore { get; set; }

        public Store()
        {
            ProductsInStore = new List<Product>()
            {
                new Product("A", 50),
                new Product("B", 30),
                new Product("C", 20),
                new Product("D", 15)
            };
        }
    }

    public class Product
    {
        public string Sku { get; private set; }
        public int Price { get; private set; }

        public Product(string sku, int price)
        {
            this.Sku = sku;
            this.Price = price;
        }
    }
}




