namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;
    using Model;

    public interface IProductImageService
    {
        ProductImage GetProductImage(int id);

        List<ProductImage> GetProductImages(int productId);

        void AddImage(ProductImage productImage);

        IEnumerable<ValidationResult> CanDeleteProductImage(ProductImage image);

        void DeleteImage(ProductImage image);
    }

    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ProductImageService(IUnitOfWork unitOfWork, IProductImageRepository productImageRepository)
        {
            _unitOfWork = unitOfWork;
            _productImageRepository = productImageRepository;
        }

        public ProductImage GetProductImage(int id)
        {
            var productImage = _productImageRepository.GetById(id);
            return productImage;
        }

        public List<ProductImage> GetProductImages(int productId)
        {
            var productImages = _productImageRepository.GetMany(x => x.ProductId == productId);
            return productImages.ToList();
        }

        public void AddImage(ProductImage productImage)
        {
            _productImageRepository.Add(productImage);
            SaveImage();
        }

        public IEnumerable<ValidationResult> CanDeleteProductImage(ProductImage image)
        {
            var productImages = _productImageRepository.GetMany(x => x.ProductId == image.ProductId);
            if (productImages.Count() == 1)
            {
                yield return new ValidationResult("Нельзя удалить последнее изображение!");
            }
        }

        public void DeleteImage(ProductImage image)
        {
            _productImageRepository.Delete(image);
            SaveImage();
        }

        private void SaveImage()
        {
            _unitOfWork.Commit();
        }
    }
}
