namespace TheShop.Tests
{
    using System;
    using FluentAssertions;
    using Model;
    using Moq;
    using NUnit.Framework;
    using Repositories.Interfaces;
    using Services;
    using Services.Interfaces;
    using Suppliers;
    using Suppliers.Interfaces;

    [TestFixture]
    public class ShopServiceTests : BaseTest
    {
        [Test]
        public void ShopService_GetById_ReturnsArticle()
        {
            // Arrange
            var article = new Article();
            Mock.Mock<IRepository<Article>>()
                .Setup(x => x.GetById(123))
                .Returns(article);

            var shopService = Mock.Create<ShopService>();

            // Act
            var result = shopService.GetById(123);

            // Assert
            result.Should().Be(article);
            Mock.Mock<IRepository<Article>>().Verify(x => x.GetById(123), Times.Once);
        }

        [Test]
        public void ShopService_GetByIdWithInvalidId_ThrowsArgumentException()
        {
            // Arrange
            Mock.Mock<IRepository<Article>>()
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Throws(new ArgumentException("The id supplied id is invalid"));

            var shopService = Mock.Create<ShopService>();

            Action action = () => shopService.GetById(0);

            // Act and Assert
            action.Should().Throw<ArgumentException>();
        }

        private IChainableSupplier CreateSupplierHierarchy()
        {
            return new ChainableSupplier(
                new Supplier1(),
                new ChainableSupplier(
                    new Supplier2(),
                    new ChainableSupplier(
                        new Supplier3(),
                        new NullChainableSupplier())));
        }
    }
}
