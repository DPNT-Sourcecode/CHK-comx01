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
            //Act
            var cart = new Cart("");
            //Assert
            cart.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void ShouldReturnFalseIfCartIsEmpty()
        {
            //Arrange
            //Act
            var cart = new Cart("ABC");
            //Assert
            cart.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void ShouldReturnTrueIfCartHasInvalidProducts()
        {
            //Arrange
            var allowedProducts = new List<Product>
            {
                new Product('A', 10, null)
            };
            //Act
            var cart = new Cart("ABC");
            //Assert
            cart.HasInvalidProduct(allowedProducts).Should().BeTrue();
        }

        [Test]
        public void ShouldReturnFalseIfCartHasValidProducts()
        {
            //Arrange
            var allowedProducts = new List<Product>
            {
                new Product('A', 10, null),
                new Product('C', 23, null)
            };
            //Act
            var cart = new Cart("ACACAAACAC");
            //Assert
            cart.HasInvalidProduct(allowedProducts).Should().BeFalse();
        }

        [Test]
        public void ShouldGetCorrectTotalPriceWithoutOffer()
        {
            //Arrange
            var allowedProducts = new List<Product>
            {
                new Product('A', 10, null)
            };
            //Act
            var cart = new Cart("AAA");
            //Assert
            cart.GetTotalPrice(allowedProducts, null).Should().Be(30);
        }

        [Test]
        public void ShouldGetCorrectTotalPriceWithOffer()
        {
            //Arrange
            var allowedProducts = new List<Product>
            {
                new Product('A', 10, new List<SpecialPriceOffer> { new SpecialPriceOffer(3, 25) })
            };
            //Act
            var cart = new Cart("AAA");
            //Assert
            cart.GetTotalPrice(allowedProducts, null).Should().Be(25);
        }

        [Test]
        public void ShouldGetCorrectTotalPriceWithOfferAndAdditionalItems()
        {
            //Arrange
            var allowedProducts = new List<Product>
            {
                new Product('A', 10, new List<SpecialPriceOffer> { new SpecialPriceOffer(3, 25) })
            };
            //Act
            var cart = new Cart("AAAA");
            //Assert
            cart.GetTotalPrice(allowedProducts, null).Should().Be(35);
        }
    }
}

