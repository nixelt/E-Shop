namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;

    using ProductFilters;

    using Model;

    public interface IProductService
    {
        Product GetProduct(int id);

        List<Product> GetProductsForCustomer(
            IProductSorter productSorter,
            List<IProductFilter> productFilters = null);

        List<Product> GetProductsForAdmin(
            IProductSorter productSorter,
            List<IProductFilter> productFilters = null);


        IEnumerable<ValidationResult> CanAddProduct(Product newProduct);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        void RestoreProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public List<Product> GetProductsForCustomer(IProductSorter productSorter, List<IProductFilter> productFilters = null)
        {
            productFilters = productFilters == null
                                 ? ProductFilterList.RequiredFiltersForCustomer()
                                 : productFilters.Union(ProductFilterList.RequiredFiltersForCustomer()).ToList();

            var products = ApplyFilters(productFilters, productSorter);
            return SortByAvailability(products);
        }

        public List<Product> GetProductsForAdmin(
            IProductSorter productSorter,
            List<IProductFilter> productFilters = null)
        {
            if (productFilters == null)
            {
                productFilters = ProductFilterList.BaseFiltersForAdmin();
            }

            var products = ApplyFilters(productFilters, productSorter);
            return products.ToList();
        }

        public IEnumerable<ValidationResult> CanAddProduct(Product newProduct)
        {
            Product product;
            if (newProduct.ProductId == 0)
            {
                product = _productRepository.Get(x => x.Name == newProduct.Name);
            }
            else
            {
                product = _productRepository.Get(
                    x => x.Name == newProduct.Name && x.ProductId != newProduct.ProductId);
            }

            if (product != null)
            {
                yield return new ValidationResult("Товар с даным именем уже существует!");
            }

            if (newProduct.OldPrice <= newProduct.Price && newProduct.OldPrice != 0)
            {
                yield return new ValidationResult("Старая цена должна быть больше новой!");
            }
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
            SaveProduct();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            SaveProduct();
        }

        public void DeleteProduct(Product product)
        {
            product.IsDeleted = true;
            _productRepository.Update(product);
            SaveProduct();
        }

        public void RestoreProduct(Product product)
        {
            product.IsDeleted = false;
            _productRepository.Update(product);
            SaveProduct();
        }

        private static List<Product> SortByAvailability(IEnumerable<Product> products)
        {
            return products.OrderByDescending(x => x.Quantity > 0 ? 1 : 0).ToList();
        }

        private IEnumerable<Product> ApplyFilters(IEnumerable<IProductFilter> productFilters, IProductSorter productSorter)
        {
            var products = _productRepository.GetAll();
            products = productFilters.Aggregate(products, (current, productFilter) => productFilter.GetEntities(current));
            var sortedProducts = productSorter.Sort(products);
            return sortedProducts;
        }

        private void SaveProduct()
        {
            _unitOfWork.Commit();
        }
    }
}
