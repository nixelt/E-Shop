﻿namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;

    using Model;

    public interface IAttributeValueService
    {
        List<AttributeValue> GetAttributeValues(int productId);

        List<string> GetDistinctValues(int attributeId, string term);

        void EditAttributeValues(List<AttributeValue> attributeValues);
    }

    public class AttributeValueService : IAttributeValueService
    {
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AttributeValueService(IAttributeValueRepository attributeValueRepository, IUnitOfWork unitOfWork)
        {
            _attributeValueRepository = attributeValueRepository;
            _unitOfWork = unitOfWork;
        }

        public List<AttributeValue> GetAttributeValues(int productId)
        {
            var attributeValues = _attributeValueRepository.GetMany(x => x.ProductId == productId).ToList();
            return attributeValues;
        }

        public List<string> GetDistinctValues(int attributeId, string term)
        {
            var attributeValues = _attributeValueRepository.GetMany(x => x.AttributeId == attributeId).Where(x => !string.IsNullOrEmpty(x.Value) && x.Value.Contains(term));
            var values = attributeValues.GroupBy(x => x.Value).Select(x => x.Key);
            return values.ToList();
        }

        public void EditAttributeValues(List<AttributeValue> attributeValues)
        {
            foreach (var attributeValue in attributeValues)
            {
                attributeValue.Value = attributeValue.Value?.Trim();
                if (attributeValue.AttributeValueId == 0)
                {
                    if (!string.IsNullOrEmpty(attributeValue.Value))
                    {
                        _attributeValueRepository.Add(attributeValue);
                    }
                }
                else if (string.IsNullOrEmpty(attributeValue.Value))
                {
                    var av = _attributeValueRepository.GetById(attributeValue.AttributeValueId);
                    _attributeValueRepository.Delete(av);
                }
                else
                {
                    _attributeValueRepository.Update(attributeValue);
                }
            }

            SaveAttributeValue();
        }

        private void SaveAttributeValue()
        {
            _unitOfWork.Commit();
        }
    }
}
