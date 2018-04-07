﻿namespace TheShop.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Repositories.Interfaces;

    //in memory implementation
    public class DatabaseDriver : IRepository
    {
        private List<Article> _articles = new List<Article>();

        public Article GetById(int id)
        {
            if (_articles.Any(x => x.ID == id))
            {
                return _articles.Single(x => x.ID == id);
            }
            throw new Exception("Could not find article with ID: " + id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}