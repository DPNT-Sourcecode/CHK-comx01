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
                new Product('A', 50, 
                    new List<SpecialPriceOffer>  { new SpecialPriceOffer(3, 130) , new SpecialPriceOffer(5, 200) }),
                new Product('B', 30, 
                    new List<SpecialPriceOffer> { new SpecialPriceOffer(2, 45) }),
                new Product('C', 20, 
                    null),
                new Product('D', 15, 
                    null),
                new Product('E', 40,
                    null,
                    new List<FreeProductOffer> { new FreeProductOffer(2, 'B') }),
                new Product('F', 10,
                    null,
                    new List<FreeProductOffer> { new FreeProductOffer(2, 'F') })
            };
        }
    }
}


