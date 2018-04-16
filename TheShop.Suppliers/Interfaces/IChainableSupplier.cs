namespace TheShop.Suppliers.Interfaces
{
    using Model;

    public interface IChainableSupplier
    {
        Article Order(int id, int maxExpectedPrice);
    }
}
