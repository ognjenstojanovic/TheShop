﻿namespace TheShop.Suppliers
{
    using Interfaces;
    using Model;
    using TheShop.Model.Interface;

    public class Supplier3<T> : ISupplier<T>
        where T : IArticle
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public T GetArticle(int id)
        {
            return new T()
            {
                ID = 1,
                Name_of_article = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}