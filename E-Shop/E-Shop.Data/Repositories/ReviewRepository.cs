namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IReviewRepository : IRepository<Review>
    {
    }

    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
