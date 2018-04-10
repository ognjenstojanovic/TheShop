namespace TheShop.Services
{
    using Interfaces;
    using Model;

    public class Supplier1 : ChainableSupplier
    {
        public Supplier1(ChainableSupplier supplier)
            : base(supplier)
        {
        }

        public Supplier1()
        {
        }

        public override bool ArticleInInventory(int id)
        {
            return true;
        }

        public override Article GetArticle(int id)
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