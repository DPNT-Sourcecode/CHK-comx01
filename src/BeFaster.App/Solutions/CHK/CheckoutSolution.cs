using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var store = new Store();
            var cart = new Cart(skus);

            if (cart.IsEmpty())
            {
                return 0;
            }

            if ( cart.HasInvalidProduct(store.ProductsInStore))
            {
                return -1;
            }

            return cart.GetTotalPrice(store.ProductsInStore);
        }
    }
}
