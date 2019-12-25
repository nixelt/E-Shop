namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IUserRepository : IRepository<User>
    {
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
