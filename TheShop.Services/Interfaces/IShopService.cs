namespace TheShop.Services.Interfaces
{
    using Model;

    public interface IShopService<T>
    {
        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);

        T GetById(int id);
    }
}
