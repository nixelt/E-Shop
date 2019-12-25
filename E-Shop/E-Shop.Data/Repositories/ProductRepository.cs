namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
