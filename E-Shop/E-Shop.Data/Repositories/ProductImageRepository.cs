namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IProductImageRepository : IRepository<ProductImage>
    {
    }

    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
