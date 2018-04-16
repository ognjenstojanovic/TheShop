namespace TheShop.Factory
{
    using Interfaces;
    using Suppliers;
    using Suppliers.Interfaces;

    public class SupplierHierarchyFactory : ISupplierHierarchyFactory
    {
        public IChainableSupplier CreateChainableSupplierHierarchy()
        {
            return new ChainableSupplier(
                new Supplier1(),
                new ChainableSupplier(
                    new Supplier2(),
                    new ChainableSupplier(
                        new Supplier3(),
                        new NullChainableSupplier())));
        }
    }
}
