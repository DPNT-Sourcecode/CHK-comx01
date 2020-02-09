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

        [TestCase("", ExpectedResult = 0)]
        public int EmptyCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

        [TestCase("E", ExpectedResult = -1)]
        [TestCase("AEB", ExpectedResult = -1)]
        public int InvalidCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("BB", ExpectedResult = 45)]
        [TestCase("BBBB", ExpectedResult = 90)]
        [TestCase("BBBBB", ExpectedResult = 120)]
        [TestCase("CCC", ExpectedResult = 60)]
        [TestCase("ABCD", ExpectedResult = 115)]
        [TestCase("ABCDABCD", ExpectedResult = 215)]
        public int SpecialOfferCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("AAAAA", ExpectedResult = 200)]
        [TestCase("AAAAAA", ExpectedResult = 250)]
        [TestCase("AAAAAAA", ExpectedResult = 300)]
        public int TwoSpecialOfferCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

    }
}

