using BuildingApi.Controllers.Common;
using BusinessRules.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Legacy;


namespace BuildingApi.Tests.Controllers.Common
{
    public class BaseControllerTests
    {
        // Test entity and controller for testing purposes  
        public class TestEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class TestController : BaseController<TestEntity, IBaseBusinessRules<TestEntity>>
        {
            public TestController(IBaseBusinessRules<TestEntity> service) : base(service) { }
        }

        private Mock<IBaseBusinessRules<TestEntity>> _mockService;
        private TestController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IBaseBusinessRules<TestEntity>>();
            _controller = new TestController(_mockService.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithData()
        {
            // Arrange  
            var testData = new List<TestEntity> { new TestEntity { Id = 1, Name = "Test" } };
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(testData);

            // Act  
            var result = await _controller.GetAll();

            // Assert  
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(testData, okResult.Value);
        }

        [Test]
        public async Task GetById_ReturnsOkResult_WithEntity()
        {
            // Arrange  
            var testEntity = new TestEntity { Id = 1, Name = "Test" };
            _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(testEntity);

            // Act  
            var result = await _controller.GetById(1);

            // Assert  
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(testEntity, okResult.Value);
        }

        [Test]
        public async Task Create_ReturnsOkResult_WithCreatedEntity()
        {
            // Arrange  
            var newEntity = new TestEntity { Id = 1, Name = "New" };
            _mockService.Setup(s => s.CreateAsync(newEntity)).ReturnsAsync(newEntity.Id);

            // Act  
            var result = await _controller.Create(newEntity);

            // Assert  
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(newEntity.Id, okResult.Value);
        }

        [Test]
        public async Task Update_ReturnsOkResult_WithUpdatedEntity()
        {
            // Arrange  
            var updatedEntity = new TestEntity { Id = 1, Name = "Updated" };
            _mockService.Setup(s => s.UpdateAsync(updatedEntity)).ReturnsAsync(true);

            // Act  
            var result = await _controller.Update(updatedEntity);

            // Assert  
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(true, okResult.Value);
        }

        [Test]
        public async Task Delete_ReturnsOkResult_WithDeletedEntityId()
        {
            // Arrange  
            var entityId = 1;
            _mockService.Setup(s => s.DeleteAsync(entityId)).ReturnsAsync(true);

            // Act  
            var result = await _controller.Delete(entityId);

            // Assert  
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(true, okResult.Value);
        }


    }
}
