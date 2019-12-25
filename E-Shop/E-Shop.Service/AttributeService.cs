namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;
    using Model;

    using Attribute = Model.Attribute;

    public interface IAttributeService
    {
        Attribute GetAttribute(int id);

        List<Attribute> GetAttributesForFiltering(int categoryId);

        IEnumerable<ValidationResult> CanAddAttribute(Attribute newAttribute);

        void CreateAttribute(Attribute attribute);

        void UpdateAttribute(Attribute attribute);
    }

    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AttributeService(IAttributeRepository attributeRepository, IUnitOfWork unitOfWork)
        {
            _attributeRepository = attributeRepository;
            _unitOfWork = unitOfWork;
        }

        public Attribute GetAttribute(int id)
        {
            var attribute = _attributeRepository.GetById(id);
            return attribute;
        }

        // Return attributes of category with distinct values 
        public List<Attribute> GetAttributesForFiltering(int categoryId)
        {
            var attributes = _attributeRepository.GetMany(x => x.CategoryId == categoryId
                                                                && x.AttributeValues.Count > 0
                                                                && x.AllowFiltering).ToList();
            foreach (var attribute in attributes)
            {
                attribute.AttributeValues = attribute.AttributeValues
                   .Where(x => !string.IsNullOrEmpty(x.Value))
                   .GroupBy(x => x.Value)
                   .Select(x => new AttributeValue { AttributeId = attribute.AttributeId, Value = x.Key })
                   .OrderBy(x => x.Value).ToList();
            }

            return attributes.ToList();
        }

        public IEnumerable<ValidationResult> CanAddAttribute(Attribute newAttribute)
        {
            Attribute attribute;
            if (newAttribute.AttributeId == 0)
            {
                attribute = _attributeRepository.Get(
                    g => g.Name == newAttribute.Name
                         && g.CategoryId == newAttribute.CategoryId);
            }
            else
            {
                attribute = _attributeRepository.Get(
                    g => g.Name == newAttribute.Name
                         && g.CategoryId == newAttribute.CategoryId
                         && g.AttributeId != newAttribute.AttributeId);
            }

            if (attribute != null)
            {
                yield return new ValidationResult("Атрибут с данным названием уже существует");
            }
        }

        public void CreateAttribute(Attribute attribute)
        {
            _attributeRepository.Add(attribute);
            SaveAttribute();
        }

        public void UpdateAttribute(Attribute attribute)
        {
            _attributeRepository.Update(attribute);
            SaveAttribute();
        }

        private void SaveAttribute()
        {
            _unitOfWork.Commit();
        }
    }
}
