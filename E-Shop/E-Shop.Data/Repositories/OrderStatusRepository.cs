namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;


    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
    }

    public class OrderStatusRepository : RepositoryBase<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
