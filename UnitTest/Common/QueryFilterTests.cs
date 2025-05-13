using NUnit.Framework.Legacy;
using Utilities.GenericQuery;
using Utilities.Objects;
using static Utilities.Utilities.Enumerations;

namespace UnitTest.Common
{
    [TestFixture]
    public class QueryFilterTests
    {
        private class TestEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Value { get; set; }
        }

        private List<TestEntity> _testData;

        [SetUp]
        public void Setup()
        {
            _testData = new List<TestEntity>
            {
                new TestEntity { Id = 1, Name = "Test1", Value = 10.5 },
                new TestEntity { Id = 2, Name = "Test2", Value = 20.5 },
                new TestEntity { Id = 3, Name = "Test3", Value = 30.5 }
            };
        }


        [Test]
        public void FilterGeneric_NoFilters_ReturnsOriginalSource()
        {
            // Arrange              
            var filters = new List<ItemFilter>();

            // Act  
            var result = _testData.AsQueryable().FilterGeneric(filters);

            // Assert  
            ClassicAssert.AreEqual(_testData.AsQueryable(), result);
        }

        [Test]
        public void FilterGeneric_SingleEqualsFilter_ReturnsFilteredSource()
        {
            // Arrange  
            var filters = new List<ItemFilter>
            {
                new ItemFilter { Name = "Id", Value = 1, Operator = FilterOperation.Equals }
            };

            // Act  
            var result = _testData.AsQueryable().FilterGeneric(filters);

            // Assert  
            ClassicAssert.AreEqual(1, result.Count());
            ClassicAssert.AreEqual(1, result.First().Id);
        }

        [Test]
        public void FilterGeneric_MultipleFilters_ReturnsFilteredSource()
        {
            // Arrange  
            var filters = new List<ItemFilter>
            {
               new ItemFilter { Name = "Value", Value = 20.5, Operator = FilterOperation.MayorEquals },
               new ItemFilter { Name = "Name", Value = "Test3", Operator = FilterOperation.Equals }
            };

            // Act  
            var result = _testData.AsQueryable().FilterGeneric(filters);

            // Assert  
            ClassicAssert.AreEqual(1, result.Count());
            ClassicAssert.AreEqual("Test3", result.First().Name);
        }

        [Test]
        public void FilterGeneric_ContainsFilter_ReturnsFilteredSource()
        {
            // Arrange              
            var filters = new List<ItemFilter>
            {
                new ItemFilter { Name = "Name", Value = "Test", Operator = FilterOperation.Contains }
            };

            // Act  
            var result = _testData.AsQueryable().FilterGeneric(filters);

            // Assert  
            ClassicAssert.AreEqual(3, result.Count());
            ClassicAssert.IsTrue(result.Any(x => x.Name == "Test1"));
            ClassicAssert.IsTrue(result.Any(x => x.Name == "Test2"));
        }
    }
}
