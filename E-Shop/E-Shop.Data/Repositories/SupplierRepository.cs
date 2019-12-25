namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface ISupplierRepository : IRepository<Supplier>
    {
    }

    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
