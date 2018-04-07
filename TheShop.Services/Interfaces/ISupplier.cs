namespace TheShop.Services.Interfaces
{
    using Model;

    public interface ISupplier
    {
        bool ArticleInInventory(int id);

        Article GetArticle(int id);
    }
}
