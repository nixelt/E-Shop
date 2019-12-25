namespace E_Shop.Data.Infrastructure
{
    using System;

    using ApplicationContext;

    /// <summary>
    ///     The factory pattern for getting a database
    /// </summary>
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationContext Get();
    }
}
