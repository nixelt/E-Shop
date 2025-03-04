// <copyright file="AttributeValueServiceTest.cs">Copyright ©  2019</copyright>
using System;
using System.Collections.Generic;
using E_Shop.Data.Infrastructure;
using E_Shop.Data.Repositories;
using E_Shop.Model;
using E_Shop.Service;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E_Shop.Service.Tests
{
    /// <summary>This class contains parameterized unit tests for AttributeValueService</summary>
    [PexClass(typeof(AttributeValueService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AttributeValueServiceTest
    {
        /// <summary>Test stub for .ctor(IAttributeValueRepository, IUnitOfWork)</summary>
        [PexMethod]
        public AttributeValueService ConstructorTest(
            IAttributeValueRepository attributeValueRepository,
            IUnitOfWork unitOfWork
        )
        {
            AttributeValueService target
               = new AttributeValueService(attributeValueRepository, unitOfWork);
            return target;
            // TODO: add assertions to method AttributeValueServiceTest.ConstructorTest(IAttributeValueRepository, IUnitOfWork)
        }

        /// <summary>Test stub for EditAttributeValues(List`1&lt;AttributeValue&gt;)</summary>
        [PexMethod]
        public void EditAttributeValuesTest(
            [PexAssumeUnderTest]AttributeValueService target,
            List<AttributeValue> attributeValues
        )
        {
            target.EditAttributeValues(attributeValues);
            // TODO: add assertions to method AttributeValueServiceTest.EditAttributeValuesTest(AttributeValueService, List`1<AttributeValue>)
        }

        /// <summary>Test stub for GetAttributeValues(Int32)</summary>
        [PexMethod]
        public List<AttributeValue> GetAttributeValuesTest(
            [PexAssumeUnderTest]AttributeValueService target,
            int productId
        )
        {
            List<AttributeValue> result = target.GetAttributeValues(productId);
            return result;
            // TODO: add assertions to method AttributeValueServiceTest.GetAttributeValuesTest(AttributeValueService, Int32)
        }

        /// <summary>Test stub for GetDistinctValues(Int32, String)</summary>
        [PexMethod]
        public List<string> GetDistinctValuesTest(
            [PexAssumeUnderTest]AttributeValueService target,
            int attributeId,
            string term
        )
        {
            List<string> result = target.GetDistinctValues(attributeId, term);
            return result;
            // TODO: add assertions to method AttributeValueServiceTest.GetDistinctValuesTest(AttributeValueService, Int32, String)
        }
    }
}
