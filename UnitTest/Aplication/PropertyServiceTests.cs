using BusinessRules.BusinessRules;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;
using Moq;
using NUnit.Framework.Legacy;
using System.Linq.Expressions;
using Utilities.Utilities;

namespace BusinessRules.Tests.BusinessRules
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> propertyRepositoryMock;
        private Mock<IOwnerService> ownerServiceMock;
        private PropertyService propertyService;

        [SetUp]
        public void SetUp()
        {
            propertyRepositoryMock = new Mock<IPropertyRepository>();
            ownerServiceMock = new Mock<IOwnerService>();
            propertyService = new PropertyService(propertyRepositoryMock.Object, ownerServiceMock.Object);
        }

        [Test]
        public async Task CreateAsync_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            // Arrange  
            var property = new Property { IdOwner = 1 };
            ownerServiceMock.Setup(x => x.GetByIdAsync(property.IdOwner)).ReturnsAsync((Owner)null);

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await propertyService.CreateAsync(property));
            ClassicAssert.AreEqual(ConstantsException.OwnerNotFound, ex.Message);
        }

        [Test]
        public async Task CreateAsync_ShouldThrowException_WhenCodeIsDuplicate()
        {
            // Arrange  
            var property = new Property { Id = 1, CodeInternal = "CODE123" };
            ownerServiceMock.Setup(x => x.GetByIdAsync(property.IdOwner)).ReturnsAsync(new Owner());
            propertyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Property, bool>>>()))
                .ReturnsAsync(new Property { Id = 2, CodeInternal = "CODE123" });

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await propertyService.CreateAsync(property));
            ClassicAssert.AreEqual(string.Format(ConstantsException.PropertyCodeDuplicate, property.CodeInternal), ex.Message);
        }

        [Test]
        public async Task CreateAsync_ShouldCallBaseCreate_WhenValidationsPass()
        {
            // Arrange  
            var property = new Property { Id = 1, IdOwner = 1, CodeInternal = "CODE123", Address = "123 Main St" };
            ownerServiceMock.Setup(x => x.GetByIdAsync(property.IdOwner)).ReturnsAsync(new Owner());
            propertyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Property, bool>>>())).ReturnsAsync((Property)null);
            propertyRepositoryMock.Setup(x => x.CreateAsync(property)).ReturnsAsync(1);

            // Act  
            var result = await propertyService.CreateAsync(property);

            // Assert  
            ClassicAssert.AreEqual(1, result);
        }

        [Test]
        public async Task UpdateAsync_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            // Arrange  
            var property = new Property { IdOwner = 1 };
            ownerServiceMock.Setup(x => x.GetByIdAsync(property.IdOwner)).ReturnsAsync((Owner)null);

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await propertyService.UpdateAsync(property));
            ClassicAssert.AreEqual(ConstantsException.OwnerNotFound, ex.Message);
        }

        [Test]
        public async Task UpdateAsync_ShouldCallBaseUpdate_WhenValidationsPass()
        {
            // Arrange  
            var property = new Property { Id = 1, IdOwner = 1, CodeInternal = "CODE123", Address = "123 Main St" };
            ownerServiceMock.Setup(x => x.GetByIdAsync(property.IdOwner)).ReturnsAsync(new Owner());
            propertyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Property, bool>>>())).ReturnsAsync((Property)null);
            propertyRepositoryMock.Setup(x => x.UpdateAsync(property)).ReturnsAsync(true);

            // Act  
            var result = await propertyService.UpdateAsync(property);

            // Assert  
            ClassicAssert.IsTrue(result);
        }
    }
}
