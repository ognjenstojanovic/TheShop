namespace TheShop.Services
{
    using Interfaces;
    using Model;

    public class Supplier3 : ChainableSupplier
    {
        public Supplier3(ChainableSupplier supplier)
            : base(supplier)
        {
        }

        public Supplier3()
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
                Name_of_article = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}