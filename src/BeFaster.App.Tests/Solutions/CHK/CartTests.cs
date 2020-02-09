using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Solutions.CHK;
using FluentAssertions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void ShouldReturnTrueIfCartIsEmpty()
        {
            //Arrange
            var cart = new Cart("");
            //Act
            //Assert
            cart.IsEmpty().Should().BeTrue();
        }
    }
}
