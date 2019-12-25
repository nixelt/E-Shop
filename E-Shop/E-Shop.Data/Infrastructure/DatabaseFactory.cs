namespace E_Shop.Data.Infrastructure
{
    using ApplicationContext;

    /// <summary>
    ///     An implementation of IDatabaseFactory
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ApplicationContext _dataContext;

        public ApplicationContext Get()
        {
            return _dataContext ?? (_dataContext = new ApplicationContext());
        }

        protected override void DisposeCore()
        {
            _dataContext?.Dispose();
        }
    }
}
