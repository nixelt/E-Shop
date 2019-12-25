namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IAttributeRepository : IRepository<Attribute>
    {
    }

    public class AttributeRepository : RepositoryBase<Attribute>, IAttributeRepository
    {
        public AttributeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
