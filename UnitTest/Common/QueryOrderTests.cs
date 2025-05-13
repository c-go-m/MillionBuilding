using NUnit.Framework.Legacy;
using Utilities.GenericQuery;
using Utilities.Objects;

namespace UnitTest.Common
{
    public class QueryOrderTests
    {
        private class TestEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private List<TestEntity> _testData;

        [SetUp]
        public void SetUp()
        {
            _testData = new List<TestEntity>
           {
               new TestEntity { Id = 2, Name = "B" },
               new TestEntity { Id = 1, Name = "A" }
           };
        }

        [Test]
        public void OrderByGeneric_WhenValidSortProvided()
        {
            // Arrange  
            var sort = new ItemSort { Name = "Id", Direction = "Ascending" };

            // Act  
            var result = _testData.AsQueryable().OrderByGeneric(sort);

            // Assert  
            ClassicAssert.AreEqual(1, result.First().Id);
            ClassicAssert.AreEqual(2, result.Last().Id);
        }

        [Test]
        public void OrderByGeneric_WhenSortIsNull()
        {
            // Act  
            var result = _testData.AsQueryable().OrderByGeneric(null);

            // Assert  
            ClassicAssert.AreEqual(_testData, result);
        }

        [Test]
        public void OrderByGeneric_WhenSortNameIsEmpty()
        {
            // Arrange  
            var sort = new ItemSort { Name = "", Direction = "Ascending" };

            // Act  
            var result = _testData.AsQueryable().OrderByGeneric(sort);

            // Assert  
            ClassicAssert.AreEqual(_testData, result);
        }

        [Test]
        public void OrderByGeneric_WhenPropertyDoesNotExist()
        {
            // Arrange              
            var sort = new ItemSort { Name = "NonExistentProperty", Direction = "Ascending" };

            // Act & Assert  
            ClassicAssert.Throws<ArgumentException>(() => _testData.AsQueryable().OrderByGeneric(sort));
        }
    }
}
