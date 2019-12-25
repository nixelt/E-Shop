namespace E_Shop.Data.Infrastructure
{
    /// <summary>
    ///     The Unit of Work pattern is used to group one or more operations into a single transaction
    /// </summary>
    public interface IUnitOfWork
    {
        void Commit();
    }
}
