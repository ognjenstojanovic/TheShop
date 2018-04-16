namespace TheShop.Suppliers
{
    using System;
    using Interfaces;
    using Model;

    public class NullChainableSupplier : IChainableSupplier
    {
        public IChainableSupplier Successor { get; set; }

        public Article Order(int id, int maxExpectedPrice)
        {
            return null;
        }

        public void SellArticle(int id, int buyerId, Article article)
        {
            Console.WriteLine("Article can't be sold!");
        }
    }
}
