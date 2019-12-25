namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}
