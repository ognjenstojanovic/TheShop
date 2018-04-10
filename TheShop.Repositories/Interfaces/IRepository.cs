namespace TheShop.Repositories.Interfaces
{
    using Model;

    public interface IRepository<T>
    {
        T GetById(int id);

        void Save(T article);
    }
}
