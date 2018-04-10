namespace TheShop.Services
{
    using System.Data.Odbc;
    using Interfaces;
    using Model;

    public abstract class ChainableSupplier : ISupplier
    {
        private ChainableSupplier Successor { get; }

        protected ChainableSupplier(ChainableSupplier successor)
        {
            Successor = successor;
        }

        protected ChainableSupplier()
        {
            Successor = null;
        }

        public abstract bool ArticleInInventory(int id);

        public abstract Article GetArticle(int id);
    }
}
