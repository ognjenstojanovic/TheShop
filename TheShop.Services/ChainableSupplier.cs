namespace TheShop.Services
{
    using TheShop.Model.Interface;
    using TheShop.Services.Interfaces;
    using TheShop.Suppliers.Interfaces;

    public class ChainableSupplier<T> : IChainableSupplier<T>
        where T : IArticle
    {
        private readonly ISupplier<T> _supplier;

        public IChainableSupplier<T> Successor { get; set; }

        public ChainableSupplier(ISupplier<T> supplier, IChainableSupplier<T> successor)
        {
            _supplier = supplier;
            Successor = successor;
        }

        public T Order(int id, int maxExpectedPrice)
        {
            if(_supplier.ArticleInInventory(id))
            {
                T article = _supplier.GetArticle(id);
                if(article.ArticlePrice < maxExpectedPrice)
                {
                    return article;
                }
            }

            return Successor.Order(id, maxExpectedPrice);
        }

        public void SellArticle(int id, int buyerId, T article)
        {
            throw new System.NotImplementedException();
        }
    }
}
