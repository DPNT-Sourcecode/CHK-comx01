using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public class Store
    {
        public List<Product> ProductsInStore { get; }

        public Store()
        {
            ProductsInStore = new List<Product>()
            {
                new Product('A', 50, new List<ProductOffer>  { new ProductOffer(3, 130) , new ProductOffer(5, 200) }),
                new Product('B', 30, new List<ProductOffer> { new ProductOffer(2, 45) }),
                new Product('C', 20, null),
                new Product('D', 15, null)
            };
        }
    }
}
