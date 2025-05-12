using BusinessRules.BusinessRules;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;
using Moq;
using NUnit.Framework.Legacy;
using Utilities.Utilities;

namespace BusinessRules.Tests
{
    [TestFixture]
    public class PropertyImageServiceTests
    {
        private Mock<IPropertyImageRepository> repositoryMock;
        private Mock<IPropertyService> propertyServiceMock;
        private PropertyImageService propertyImageService;

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IPropertyImageRepository>();
            propertyServiceMock = new Mock<IPropertyService>();
            propertyImageService = new PropertyImageService(repositoryMock.Object, propertyServiceMock.Object);
        }

        [Test]
        public async Task CreateAsync_PropertyDoesNotExist_ShouldThrowApplicationException()
        {
            // Arrange  
            var propertyImage = new PropertyImage { Id = 1 };
            propertyServiceMock.Setup(s => s.GetByIdAsync(propertyImage.Id)).ReturnsAsync(new Property());

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await propertyImageService.CreateAsync(propertyImage));
            ClassicAssert.AreEqual(ConstantsException.PropertyCodeDuplicate, ex.Message);
        }

        [Test]
        public async Task CreateAsync_PropertyDoesNotExist_ShouldCallBaseCreateAsync()
        {
            // Arrange  
            var propertyImage = new PropertyImage { Id = 1 };
            propertyServiceMock.Setup(s => s.GetByIdAsync(propertyImage.Id)).ReturnsAsync((Property)null);
            repositoryMock.Setup(r => r.CreateAsync(propertyImage)).ReturnsAsync(1);

            // Act  
            var result = await propertyImageService.CreateAsync(propertyImage);

            // Assert  
            ClassicAssert.AreEqual(1, result);
            repositoryMock.Verify(r => r.CreateAsync(propertyImage), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_PropertyDoesNotExist_ShouldThrowApplicationException()
        {
            // Arrange  
            var propertyImage = new PropertyImage { Id = 1 };
            propertyServiceMock.Setup(s => s.GetByIdAsync(propertyImage.Id)).ReturnsAsync(new Property());

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await propertyImageService.UpdateAsync(propertyImage));
            ClassicAssert.AreEqual(ConstantsException.PropertyCodeDuplicate, ex.Message);
        }

        [Test]
        public async Task UpdateAsync_PropertyDoesNotExist_ShouldCallBaseUpdateAsync()
        {
            // Arrange  
            var propertyImage = new PropertyImage { Id = 1 };
            propertyServiceMock.Setup(s => s.GetByIdAsync(propertyImage.Id)).ReturnsAsync((Property)null);
            repositoryMock.Setup(r => r.UpdateAsync(propertyImage)).ReturnsAsync(true);

            // Act  
            var result = await propertyImageService.UpdateAsync(propertyImage);

            // Assert  
            ClassicAssert.IsTrue(result);
            repositoryMock.Verify(r => r.UpdateAsync(propertyImage), Times.Once);
        }
    }
}
