namespace TheShop.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Repositories.Interfaces;
    using TheShop.Model.Interface;

    //in memory implementation
    public class DatabaseDriver<T> : IRepository<T>
        where T : IArticle
    {
        private List<T> _articles = new List<T>();

        public T GetById(int id)
        {
            if (_articles.Any(x => x.ID == id))
            {
                return _articles.Single(x => x.ID == id);
            }
            throw new Exception("Could not find article with ID: " + id);
        }

        public void Save(T article)
        {
            _articles.Add(article);
        }
    }
}