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

        [TestCase("1", ExpectedResult = -1)]
        [TestCase("A7B", ExpectedResult = -1)]
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

        [TestCase("EE", ExpectedResult = 80)]
        [TestCase("BEE", ExpectedResult = 80)]
        [TestCase("EBE", ExpectedResult = 80)]
        [TestCase("EEB", ExpectedResult = 80)]
        [TestCase("EEBB", ExpectedResult = 110)]
        [TestCase("EEBE", ExpectedResult = 120)]
        [TestCase("EEBEEB", ExpectedResult = 160)]
        [TestCase("EEBEEBB", ExpectedResult = 190)]
        public int DifferentFreeProductOfferCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

        [TestCase("F", ExpectedResult = 10)]
        [TestCase("FF", ExpectedResult = 20)]
        [TestCase("FFF", ExpectedResult = 20)]
        [TestCase("FFFF", ExpectedResult = 30)]
        [TestCase("FFFFF", ExpectedResult = 40)]
        [TestCase("FFFFFF", ExpectedResult = 40)]
        [TestCase("FFFFFFF", ExpectedResult = 50)]
        public int SameFreeProductOfferCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

        [TestCase("STXF", ExpectedResult = 55)]
        [TestCase("STXSTXFF", ExpectedResult = 110)]
        [TestCase("STXSYZFFF", ExpectedResult = 110)]
        [TestCase("SSSZ", ExpectedResult = 65)]
        [TestCase("ZZZS", ExpectedResult = 65)]
        [TestCase("STXS", ExpectedResult = 62)]
        public int GroupOfferCart(string cartItems)
        {
            return CheckoutSolution.ComputePrice(cartItems);
        }

    }
}

