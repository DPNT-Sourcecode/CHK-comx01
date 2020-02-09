using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Solutions.HLO;
using FluentAssertions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    class HelloWorldTests
    {
        [Test]
        public void ReturnStringTest()
        {
            HelloSolution.Hello("").Should().Be("Hello World!");

        }

    }
}
