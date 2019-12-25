namespace E_Shop.Data.Infrastructure
{
    using ApplicationContext;
    
    /// <summary>
    ///    An implementation of IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private ApplicationContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected ApplicationContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.Get());

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
