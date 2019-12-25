namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
