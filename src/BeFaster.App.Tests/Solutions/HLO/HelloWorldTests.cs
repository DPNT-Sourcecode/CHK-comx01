using NUnit.Framework;
using FluentAssertions;
using BeFaster.App.Solutions.HLO;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloWorldTests
    {
        [Test]
        public void ReturnStringTest()
        {
            HelloSolution.Hello("").Should().Be("Hello, World!");

        }

    }
}


