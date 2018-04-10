namespace TheShop.Suppliers.Interfaces
{
    public interface ISupplier<T>
    {
        bool ArticleInInventory(int id);

        T GetArticle(int id);
    }
}
