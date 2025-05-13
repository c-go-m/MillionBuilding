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
    public class PropertyTraceServiceTests
    {
        private Mock<IPropertyTraceRepository> mockRepository;
        private Mock<IPropertyService> mockPropertyService;
        private PropertyTraceService propertyTraceService;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IPropertyTraceRepository>();
            mockPropertyService = new Mock<IPropertyService>();
            propertyTraceService = new PropertyTraceService(mockRepository.Object, mockPropertyService.Object);
        }

        [Test]
        public async Task CreateAsync_PropertyExists_ThrowsApplicationException()
        {
            // Arrange  
            var propertyTrace = new PropertyTrace { Id = 1 };
            mockPropertyService.Setup(s => s.GetByIdAsync(propertyTrace.Id))
                .ReturnsAsync(new Property());

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () =>
                await propertyTraceService.CreateAsync(propertyTrace));
            ClassicAssert.AreEqual(ConstantsException.PropertyCodeDuplicate, ex.Message);
        }

        [Test]
        public async Task CreateAsync_PropertyDoesNotExist_CallsBaseCreateAsync()
        {
            // Arrange  
            var propertyTrace = new PropertyTrace { Id = 1 };
            mockPropertyService.Setup(s => s.GetByIdAsync(propertyTrace.Id))
                .ReturnsAsync((Property)null);
            mockRepository.Setup(r => r.CreateAsync(propertyTrace))
                .ReturnsAsync(1);

            // Act  
            var result = await propertyTraceService.CreateAsync(propertyTrace);

            // Assert  
            ClassicAssert.AreEqual(1, result);
            mockRepository.Verify(r => r.CreateAsync(propertyTrace), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_PropertyExists_ThrowsApplicationException()
        {
            // Arrange  
            var propertyTrace = new PropertyTrace { Id = 1 };
            mockPropertyService.Setup(s => s.GetByIdAsync(propertyTrace.Id))
                .ReturnsAsync(new Property());

            // Act & Assert  
            var ex = Assert.ThrowsAsync<ApplicationException>(async () =>
                await propertyTraceService.UpdateAsync(propertyTrace));
            ClassicAssert.AreEqual(ConstantsException.PropertyCodeDuplicate, ex.Message);
        }

        [Test]
        public async Task UpdateAsync_PropertyDoesNotExist_CallsBaseUpdateAsync()
        {
            // Arrange  
            var propertyTrace = new PropertyTrace { Id = 1 };
            mockPropertyService.Setup(s => s.GetByIdAsync(propertyTrace.Id))
                .ReturnsAsync((Property)null);
            mockRepository.Setup(r => r.UpdateAsync(propertyTrace))
                .ReturnsAsync(true);

            // Act  
            var result = await propertyTraceService.UpdateAsync(propertyTrace);

            // Assert  
            ClassicAssert.IsTrue(result);
            mockRepository.Verify(r => r.UpdateAsync(propertyTrace), Times.Once);
        }
    }
}
