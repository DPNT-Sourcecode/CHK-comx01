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
    public class ProductOfferTests
    {
        [Test]
        public void ShouldSetupCorrect()
        {
            //Arrange
            var count = 2;
            var specialPrice = 20;
            var productOffer = new ProductOffer(count, specialPrice);
            //Act

            //Assert
            productOffer.Count.Should().Be(count);
            productOffer.SpecialPrice.Should().Be(specialPrice);
        }

    }
}
