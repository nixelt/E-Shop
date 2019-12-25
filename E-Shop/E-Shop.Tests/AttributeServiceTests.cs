namespace E_Shop.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;
    using Service;

    using Moq;

    using NUnit.Framework;

    using Attribute = Model.Attribute;

    [TestFixture]
    public class AttributeServiceTests
    {
        private readonly AttributeService _attributeService;
        private readonly Mock<IAttributeRepository> _attributeRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly List<Attribute> _attributes;

        public AttributeServiceTests()
        {
            _attributeRepository = new Mock<IAttributeRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _attributes = new List<Attribute>
                              {
                                  new Attribute { AttributeId = 1, CategoryId = 2, Name = "Test1" },
                                new Attribute { AttributeId = 2, CategoryId = 2, Name = "Test2" },
                                  new Attribute { AttributeId = 3, CategoryId = 1, Name = "Test3" },
                                  new Attribute { AttributeId = 4, CategoryId = 2, Name = "Test4" },
                                  new Attribute { AttributeId = 5, CategoryId = 2, Name = "Test5" },
                                  new Attribute { AttributeId = 6, CategoryId = 2, Name = "Test6" },
                              };
            _attributeService = new AttributeService(_attributeRepository.Object, _unitOfWork.Object);
        }

        [Test]
        public void AttributeServiceTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetAttributeTest()
        {
            var attributeId = 1;
            _attributeRepository.Setup(e => e.GetById(It.IsAny<long>()))
                    .Returns(_attributes.First(x => x.AttributeId == attributeId));

            var res = _attributeService.GetAttribute(attributeId);

            Assert.IsNotNull(res);
            Assert.AreEqual(_attributes.First(x => x.AttributeId == attributeId), res);
        }

        [Test]
        public void GetAttributesTest()
        {
           Assert.Fail();
        }

        [Test]
        public void GetAttributesForFilteringTest()
        {
            Assert.Fail();
        }

        [Test]
        public void CanAddAttributeTest()
        {
            Assert.Fail();
        }

        [Test]
        public void CreateAttributeTest()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateAttributeTest()
        {
            Assert.Fail();
        }
    }
}