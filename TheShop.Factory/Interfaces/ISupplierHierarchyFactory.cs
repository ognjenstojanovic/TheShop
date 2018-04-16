namespace TheShop.Factory.Interfaces
{
    using Suppliers.Interfaces;

    public interface ISupplierHierarchyFactory
    {
        IChainableSupplier CreateChainableSupplierHierarchy();
    }
}
