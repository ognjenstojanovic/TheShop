namespace TheShop.Repositories.Interfaces
{
    using Model;

    public interface IRepository
    {
        Article GetById(int id);

        void Save(Article article);
    }
}
