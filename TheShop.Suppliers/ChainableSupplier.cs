namespace TheShop.Suppliers
{
    using Interfaces;
    using Model;

    public class ChainableSupplier : IChainableSupplier
    {
        private readonly ISupplier _supplier;

        public IChainableSupplier Successor { get; set; }

        public ChainableSupplier(ISupplier supplier, IChainableSupplier successor)
        {
            _supplier = supplier;
            Successor = successor;
        }

        public Article Order(int id, int maxExpectedPrice)
        {
            if(_supplier.ArticleInInventory(id))
            {
                Article article = _supplier.GetArticle(id);
                if(article.ArticlePrice < maxExpectedPrice)
                {
                    article.SupplierId = _supplier.Id;
                    return article;
                }
            }

            return Successor.Order(id, maxExpectedPrice);
        }

        public void SellArticle(int id, int buyerId, Article article)
        {
            throw new System.NotImplementedException();
        }
    }
}
