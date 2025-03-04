// <copyright file="AttributeServiceTest.cs">Copyright ©  2019</copyright>

namespace E_Shop.Service.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using E_Shop.Data.Infrastructure;
    using E_Shop.Data.Repositories;
    using E_Shop.Model;
    using E_Shop.Service;

    using Microsoft.Pex.Framework;
    using Microsoft.Pex.Framework.Validation;

    using NUnit.Framework;

    using Attribute = E_Shop.Model.Attribute;

    /// <summary>This class contains parameterized unit tests for AttributeService</summary>
    [PexClass(typeof(AttributeService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class AttributeServiceTests
    {
        /// <summary>Test stub for CanAddAttribute(Attribute)</summary>
        [PexMethod]
        public IEnumerable<ValidationResult> CanAddAttributeTest(
            [PexAssumeUnderTest]AttributeService target,
            Attribute newAttribute
        )
        {
            IEnumerable<ValidationResult> result = target.CanAddAttribute(newAttribute);
            return result;
            // TODO: add assertions to method AttributeServiceTest.CanAddAttributeTest(AttributeService, Attribute)
        }

        /// <summary>Test stub for .ctor(IUnitOfWork, IAttributeRepository)</summary>
        [PexMethod]
        public AttributeService ConstructorTest(IUnitOfWork unitOfWork, IAttributeRepository attributeRepository)
        {
            AttributeService target = new AttributeService(unitOfWork, attributeRepository);
            return target;
            // TODO: add assertions to method AttributeServiceTest.ConstructorTest(IUnitOfWork, IAttributeRepository)
        }

        /// <summary>Test stub for CreateAttribute(Attribute)</summary>
        [PexMethod]
        public void CreateAttributeTest(
            [PexAssumeUnderTest]AttributeService target,
            Attribute attribute
        )
        {
            target.CreateAttribute(attribute);
            // TODO: add assertions to method AttributeServiceTest.CreateAttributeTest(AttributeService, Attribute)
        }

        /// <summary>Test stub for GetAttribute(Int32)</summary>
        [PexMethod]
        public Attribute GetAttributeTest([PexAssumeUnderTest]AttributeService target, int id)
        {
            Attribute result = target.GetAttribute(id);
            return result;
            // TODO: add assertions to method AttributeServiceTest.GetAttributeTest(AttributeService, Int32)
        }

        /// <summary>Test stub for GetAttributesForFiltering(Int32)</summary>
        [PexMethod]
        public List<Attribute> GetAttributesForFilteringTest([PexAssumeUnderTest]AttributeService target, int categoryId)
        {
            List<Attribute> result = target.GetAttributesForFiltering(categoryId);
            return result;
            // TODO: add assertions to method AttributeServiceTest.GetAttributesForFilteringTest(AttributeService, Int32)
        }

        /// <summary>Test stub for GetAttributes(Int32)</summary>
        [PexMethod]
        public List<Attribute> GetAttributesTest([PexAssumeUnderTest]AttributeService target, int categoryId)
        {
            List<Attribute> result = target.GetAttributes(categoryId);
            return result;
            // TODO: add assertions to method AttributeServiceTest.GetAttributesTest(AttributeService, Int32)
        }

        /// <summary>Test stub for UpdateAttribute(Attribute)</summary>
        [PexMethod]
        public void UpdateAttributeTest(
            [PexAssumeUnderTest]AttributeService target,
            Attribute attribute
        )
        {
            target.UpdateAttribute(attribute);
            // TODO: add assertions to method AttributeServiceTest.UpdateAttributeTest(AttributeService, Attribute)
        }
    }
}
