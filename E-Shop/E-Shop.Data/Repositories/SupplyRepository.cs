namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface ISupplyRepository : IRepository<Supply>
    {
    }

    public class SupplyRepository : RepositoryBase<Supply>, ISupplyRepository
    {
        public SupplyRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
