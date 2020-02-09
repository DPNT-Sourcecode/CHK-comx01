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
            store.ProductsInStore.Count().Should().Be(4);
        }

    }
}
