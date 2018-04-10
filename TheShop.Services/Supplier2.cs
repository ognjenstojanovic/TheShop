namespace TheShop.Services
{
    using Interfaces;
    using Model;

    public class Supplier2 : ChainableSupplier
    {
        public Supplier2(ChainableSupplier supplier)
            : base(supplier)
        {
        }

        public Supplier2()
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
                Name_of_article = "Article from supplier2",
                ArticlePrice = 459
            };
        }
    }
}