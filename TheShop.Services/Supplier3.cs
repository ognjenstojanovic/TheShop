﻿namespace TheShop.Services
{
    using Model;

    public class Supplier3
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
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