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
            return _articles.SingleOrDefault(x => x.ID == id);
        }

        public void Save(T article)
        {
            _articles.Add(article);
        }
    }
}