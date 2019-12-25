namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface ISupplyProductRepository : IRepository<SupplyProduct>
    {
    }

    public class SupplyProductRepository : RepositoryBase<SupplyProduct>, ISupplyProductRepository
    {
        public SupplyProductRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
