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
    public class ProductTests
    {
        [Test]
        public void ShouldSetupCorrect()
        {
            //Arrange
            var product = new Product('A', 10, null);
            //Act
            //Assert
            product.Sku.Should().Be('A');
            product.Price.Should().Be(10);
            product.Offer.Should().BeNull();
        }

        [Test]
        public void ShouldCalculateCorrectPriceWithoutOffer()
        {
            //Arrange
            var product = new Product('A', 10, null);
            //Act
            var totalPrice = product.GetPrice("AAA");
            //Assert
            totalPrice.Should().Be(30);
        }

        [Test]
        public void ShouldCalculateCorrectPriceWithOffer()
        {
            //Arrange
            var product = new Product('A', 10, new List<SpecialPriceOffer> {new SpecialPriceOffer(3, 25)});
            //Act
            var totalPrice = product.GetPrice("AAA");
            //Assert
            totalPrice.Should().Be(25);
        }
    }
}


