namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
    }

    public class OrderDetailsRepository : RepositoryBase<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
