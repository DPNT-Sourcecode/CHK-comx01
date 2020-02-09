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
    public class StoreTests
    {
        [Test]
        public void ShouldHave4AllowedProducts()
        {
            //Arrange
            var store = new Store();
            //Act

            //Assert
            store.ProductsInStore.Count().Should().Be(26);
        }

        [Test]
        public void ShouldHave7SpecialOfferProducts()
        {
            //Arrange
            var store = new Store();
            //Act

            //Assert
            store.ProductsInStore.Count(p => p.Offer != null).Should().Be(7);
        }

        [Test]
        public void ShouldHave5FreeOfferProducts()
        {
            //Arrange
            var store = new Store();
            //Act

            //Assert
            store.ProductsInStore.Count(p => p.FreeOffer != null).Should().Be(5);
        }

    }
}
