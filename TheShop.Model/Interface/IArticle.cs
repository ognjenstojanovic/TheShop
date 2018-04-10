namespace TheShop.Model.Interface
{
    public interface IArticle
    {
        int ID { get; set; }

        string Name_of_article { get; set; }

        int ArticlePrice { get; set; }

        IArticle Sell(int buyerId);
    }
}
