namespace TheShop.Services
{
    using System;
    using Interfaces;
    using Model;
    using Repositories.Interfaces;
    using TheShop.Model.Interface;
    using TheShop.Suppliers;

    public class ShopService<T> : IShopService<T> 
        where T : IArticle
	{
		private readonly IRepository<T> _databaseDriver;
		private readonly ILogger _logger;
        private IChainableSupplier<T> _top;
		
		public ShopService(
		    IRepository<T> repository,
		    ILogger logger)
		{
			_databaseDriver = repository;
		    _logger = logger;

            CreateSupplierHierarchy();
		}

        private void CreateSupplierHierarchy()
        {
            _top = new ChainableSupplier<T>(
                new Supplier1<T>(),
                new ChainableSupplier<T>(
                    new Supplier2<T>(),
                    new ChainableSupplier<T>(
                        new Supplier3<T>(),
                        new NullChainableSupplier<T>())));
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            T article = OrderArticle(id, maxExpectedPrice);
            SellArticle(id, buyerId, article);
        }

	    private T OrderArticle(int id, int maxExpectedPrice)
	    {
            return _top.Order(id, maxExpectedPrice);            
	    }

        private void SellArticle(int id, int buyerId, T article)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Debug("Trying to sell article with id=" + id);

            article.Sell(buyerId);            

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

        public T GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}
}

// Old order implementation
/*
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
     */
