using System.Collections.Generic;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            productsInStore = InitialiseStore();

        }

        public static List<Product> InitialiseStore()
        {
            return new List<Product>()
            {
                new Product { Sku = "A", Price = 50 },
                new Product { Sku = }
            };
        }
    }

    public class Product
    {
        public string Sku { get; private set; }
        public int Price { get; private set; }

        public Product(string sku, string price)
        {
            this.Sku = sku;
            this.Price = price;
        }
    }
}

