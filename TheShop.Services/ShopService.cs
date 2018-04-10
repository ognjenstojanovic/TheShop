namespace TheShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Model;
    using Repositories;
    using Repositories.Interfaces;

    public class ShopService : IShopService
	{
		private readonly IRepository _databaseDriver;
		private readonly ILogger _logger;

		private readonly ChainableSupplier _supplier1;
		private readonly ChainableSupplier _supplier2;
		private readonly ChainableSupplier _supplier3;
		
		public ShopService(
		    IRepository repository,
		    ILogger logger)
		{
			_databaseDriver = repository;
		    _logger = logger;

			_supplier1 = new Supplier1();
			_supplier2 = new Supplier2(_supplier1);
			_supplier3 = new Supplier3(_supplier2);
		}

	    public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            Article article = OrderArticle(id, maxExpectedPrice);
            SellArticle(id, buyerId, article);
        }

	    private Article OrderArticle(int id, int maxExpectedPrice)
	    {
	        Article article = null;
	        Article tempArticle = null;
	        var articleExists = _supplier1.ArticleInInventory(id);
	        if (articleExists)
	        {
	            tempArticle = _supplier1.GetArticle(id);
	            if (maxExpectedPrice < tempArticle.ArticlePrice)
	            {
	                articleExists = _supplier2.ArticleInInventory(id);
	                if (articleExists)
	                {
	                    tempArticle = _supplier2.GetArticle(id);
	                    if (maxExpectedPrice < tempArticle.ArticlePrice)
	                    {
	                        articleExists = _supplier3.ArticleInInventory(id);
	                        if (articleExists)
	                        {
	                            tempArticle = _supplier3.GetArticle(id);
	                            if (maxExpectedPrice < tempArticle.ArticlePrice)
	                            {
	                                article = tempArticle;
	                            }
	                        }
	                    }
	                }
	            }
	        }

	        article = tempArticle;
	        return article;
	    }

        private void SellArticle(int id, int buyerId, Article article)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                _databaseDriver.Save(article);
                _logger.Info("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }
        }

        public Article GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}
}
