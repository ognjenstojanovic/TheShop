namespace TheShop.Model
{
    using System;
    using TheShop.Model.Interface;

    public class Article : IArticle
    {
        public int ID { get; set; }

        public string Name_of_article { get; set; }

        public int ArticlePrice { get; set; }
        public bool IsSold { get; set; }

        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }

        public IArticle Sell(int buyerId)
        {
            return new Article
            {
                IsSold = true,
                SoldDate = DateTime.Now,
                BuyerUserId = buyerId,
                ID = ID,
                Name_of_article = Name_of_article,
                ArticlePrice = ArticlePrice
            };
        }

        public int SupplierId { get; set; }
    }
}