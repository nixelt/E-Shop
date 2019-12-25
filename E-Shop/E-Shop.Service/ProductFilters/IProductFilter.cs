namespace E_Shop.Service.ProductFilters
{
    using System.Collections.Generic;

    using Model;

    /// <summary>
    ///     The strategy pattern for filtering
    /// </summary>
    public interface IProductFilter
    {
        IEnumerable<Product> GetEntities(IEnumerable<Product> products);
    }
}
