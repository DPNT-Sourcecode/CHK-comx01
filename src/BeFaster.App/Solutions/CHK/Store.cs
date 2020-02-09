using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public class Store
    {
        public List<Product> ProductsInStore { get; }
        public GroupOffer GroupOffer { get; }

        public Store()
        {
            ProductsInStore = new List<Product>()
            {
                new Product('A', 50, 
                    new List<SpecialPriceOffer>  { new SpecialPriceOffer(3, 130) , new SpecialPriceOffer(5, 200) }),
                new Product('B', 30, 
                    new List<SpecialPriceOffer> { new SpecialPriceOffer(2, 45) }),
                new Product('C', 20),
                new Product('D', 15),
                new Product('E', 40,
                    null,
                    new List<FreeProductOffer> { new FreeProductOffer(2, 'B') }),
                new Product('F', 10,
                    null,
                    new List<FreeProductOffer> { new FreeProductOffer(2, 'F') }),
                new Product('G', 20),
                new Product('H', 10,
                    new List<SpecialPriceOffer> { new SpecialPriceOffer(5, 45), new SpecialPriceOffer(10, 80) }),
                new Product('I', 35),
                new Product('J', 60),
                new Product('K', 70, 
                    new List<SpecialPriceOffer> { new SpecialPriceOffer(2, 120) }),
                new Product('L', 90),
                new Product('M', 15),
                new Product('N', 40, null,
                    new List<FreeProductOffer> { new FreeProductOffer(3, 'M') }),
                new Product('O', 10),
                new Product('P', 50, new List<SpecialPriceOffer> { new SpecialPriceOffer(5, 200) }),
                new Product('Q', 30, new List<SpecialPriceOffer> { new SpecialPriceOffer(3, 80) }),
                new Product('R', 50, null,
                    new List<FreeProductOffer> { new FreeProductOffer(3, 'Q') }),
                new Product('S', 20),
                new Product('T', 20),
                new Product('U', 40, null,
                    new List<FreeProductOffer> { new FreeProductOffer(3, 'U') }),
                new Product('V', 50, 
                    new List<SpecialPriceOffer> { new SpecialPriceOffer(2, 90), new SpecialPriceOffer(3, 130)}),
                new Product('W', 20),
                new Product('X', 17),
                new Product('Y', 20),
                new Product('Z', 21)
            };


            GroupOffer = new GroupOffer(new List<char> {'Z', 'S', 'T', 'Y', 'X'}, 45, 3);
        }
    }
}