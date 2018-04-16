namespace TheShop.Suppliers
{
    using Interfaces;
    using Model;
    using TheShop.Model.Interface;

    public class Supplier1 : ISupplier
    {
        public int Id { get; set; }

        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                Name_of_article = "Article from supplier1",
                ArticlePrice = 458
            };
        }
    }
}