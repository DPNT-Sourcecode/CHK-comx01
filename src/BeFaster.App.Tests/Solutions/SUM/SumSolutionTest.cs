using System;
using BeFaster.App.Solutions.SUM;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class SumSolutionTest
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(100, 100, ExpectedResult = 200)]
        public int ComputeSum(int x, int y)
        {
            return SumSolution.Sum(x, y);
        }

        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        public void NegativeValueCheck(int x, int y)
        {
            Assert.Throws(typeof(ArgumentException), () => SumSolution.Sum(-1, 0));
        }

    }
}



