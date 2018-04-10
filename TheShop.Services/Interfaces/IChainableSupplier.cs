namespace TheShop.Services.Interfaces
{
    public interface IChainableSupplier<T>
    {
        IChainableSupplier<T> Successor { get; set; }

        T Order(int id, int maxExpectedPrice);

        void SellArticle(int id, int buyerId, T article);
    }
}
