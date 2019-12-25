namespace E_Shop.Data.Repositories
{
    using Infrastructure;
    using Model;

    public interface IAttributeValueRepository : IRepository<AttributeValue>
    {
    }

    public class AttributeValueRepository : RepositoryBase<AttributeValue>, IAttributeValueRepository
    {
        public AttributeValueRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
