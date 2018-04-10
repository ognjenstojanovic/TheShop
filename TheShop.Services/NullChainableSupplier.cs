namespace TheShop.Services
{
    using System;
    using TheShop.Services.Interfaces;

    public class NullChainableSupplier<T> : IChainableSupplier<T>
    {
        public IChainableSupplier<T> Successor { get; set; }

        public T Order(int id, int maxExpectedPrice)
        {
            return default(T);
        }

        public void SellArticle(int id, int buyerId, T article)
        {
            Console.WriteLine("Article can't be sold!");
        }
    }
}
