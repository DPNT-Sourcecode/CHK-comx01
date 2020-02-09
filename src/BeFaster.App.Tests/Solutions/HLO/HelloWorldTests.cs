using NUnit.Framework;
using FluentAssertions;
using BeFaster.App.Solutions.HLO;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloWorldTests
    {
        [TestCase("John", ExpectedResult = "Hello, John!")]
        public string ReturnStringTest(string name)
        {
            return HelloSolution.Hello(name);
        }

    }
}



