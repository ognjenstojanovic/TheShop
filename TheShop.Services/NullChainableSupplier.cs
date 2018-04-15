namespace TheShop.Services
{
    using System;
    using TheShop.Services.Interfaces;

    public class NullChainableSupplier<T> : IChainableSupplier<T>
    {
        private readonly ILogger _logger;

        public NullChainableSupplier(ILogger logger)
        {
            _logger = logger;
        }

        public IChainableSupplier<T> Successor { get; set; }

        public T Order(int id, int maxExpectedPrice)
        {
            _logger.Info("Article with Id = " + id + " and price " + maxExpectedPrice + " or less was not found.");
            return default(T);
        }

        public void SellArticle(int id, int buyerId, T article)
        {
            Console.WriteLine("Article can't be sold!");
        }
    }
}
