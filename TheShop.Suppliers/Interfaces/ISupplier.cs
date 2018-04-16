namespace TheShop.Suppliers.Interfaces
{
    using Model;

    public interface ISupplier
    {
        int Id { get; set; }

        bool ArticleInInventory(int id);

        Article GetArticle(int id);
    }
}
