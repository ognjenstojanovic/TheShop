namespace TheShop.Services
{
    using System;
    using Factory.Interfaces;
    using Interfaces;
    using Model;
    using Repositories.Interfaces;
    using Suppliers.Interfaces;
    using TheShop.Model.Interface;
    using TheShop.Suppliers;

    public class ShopService : IShopService
    {
        private readonly IRepository<Article> _databaseDriver;
        private readonly ILogger _logger;
        private readonly ISupplierHierarchyFactory _factory;
        private readonly IChainableSupplier _top;

        public ShopService(
            IRepository<Article> repository,
            ILogger logger,
            ISupplierHierarchyFactory factory)
        {
            _databaseDriver = repository;
            _logger = logger;
            _factory = factory;

            _top = _factory.CreateChainableSupplierHierarchy();
        }        

        public Article GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Format of argument " + nameof(id) + " is not valid.");

            _logger.Info("Looking for Article with Id = " + id);
            Article article = _databaseDriver.GetById(id);
            if (article == null)
            {
                _logger.Info("Article with Id = " + id + " not found.");
            }

            return article;
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            if (id <= 0) throw new ArgumentException("Format of argument " + nameof(id) + " is not valid.");
            if (maxExpectedPrice <= 0) throw new ArgumentException("Format of argument " + nameof(maxExpectedPrice) + " is not valid.");
            if (buyerId <= 0) throw new ArgumentException("Format of argument " + nameof(buyerId) + " is not valid.");

            _logger.Info("Trying to order Article with id = " + id);

            Article article = OrderArticle(id, maxExpectedPrice);
            if (article != null)
            {
                _logger.Info("Article with id = " + id + " found at Supplier with id = " + article.SupplierId);
                SellArticle(id, buyerId, article);
            }
            else
            {
                _logger.Info("Article with id = " + id + " with price = " + maxExpectedPrice + " was not found.");
            }            
        }

        private Article OrderArticle(int id, int maxExpectedPrice)
        {
            return _top.Order(id, maxExpectedPrice);
        }

        private void SellArticle(int id, int buyerId, Article article)
        {
            _logger.Info("Trying to sell article with id = " + id);
            article.Sell(buyerId);
            _databaseDriver.Save(article);
            _logger.Info("Article with id = " + id + " is sold.");
        }        
    }
}