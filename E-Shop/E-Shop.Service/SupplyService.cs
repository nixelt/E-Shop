namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;
    using Model;

    public interface ISupplyService
    {
        Supply GetSupply(int id);

        List<Supply> GetSupplies(int? supplierId = null);

        void CreateSupply(Supply supply);
    }

    public class SupplyService : ISupplyService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplyRepository _supplyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplyService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _supplyRepository = supplyRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public Supply GetSupply(int id)
        {
            var supply = _supplyRepository.Get(x => x.SupplyId == id);
            return supply;
        }

        public List<Supply> GetSupplies(int? supplierId = null)
        {
            var supplies = supplierId == null
                               ? _supplyRepository.GetAll()
                               : _supplyRepository.GetMany(x => x.SupplierId == supplierId);
            supplies = supplies.OrderByDescending(x => x.SupplyId);
            return supplies.ToList();
        }

        public void CreateSupply(Supply supply)
        {
            _supplyRepository.Add(supply);
            foreach (var supplyProduct in supply.SupplyProducts)
            {
                var product = _productRepository.GetById(supplyProduct.ProductId);
                if (product == null)
                {
                    continue;
                }

                supplyProduct.Product.Quantity += supplyProduct.Quantity;
                _productRepository.Update(supplyProduct.Product);
            }

            SaveSupply();
        }

        private void SaveSupply()
        {
            _unitOfWork.Commit();
        }
    }
}
