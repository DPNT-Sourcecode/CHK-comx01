using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase("A", ExpectedResult = 50)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("C", ExpectedResult = 20)]
        [TestCase("D", ExpectedResult = 15)]
        public int CartTotal(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

    }
}

