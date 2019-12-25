namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface ILogRepository : IRepository<Log>
    {
    }

    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
