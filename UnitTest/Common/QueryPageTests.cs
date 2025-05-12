using NUnit.Framework.Legacy;
using Utilities.GenericQuery;
using Utilities.Objects;

namespace UnitTest.Common
{
    [TestFixture]
    public class QueryPageTests
    {
        private IQueryable<int> _testData;

        [SetUp]
        public void SetUp()
        {
            _testData = Enumerable.Range(1, 100).AsQueryable();
        }

        [Test]
        public void Page_NullPageInfo_ReturnsSource()
        {
            // Act  
            var result = _testData.Page(null);

            // Assert  
            ClassicAssert.AreEqual(_testData, result);
        }

        [Test]
        public void Page_InvalidPageNumber_ReturnsSource()
        {
            // Arrange  
            var pageInfo = new ItemPage { Page = 0, PageSize = 10 };

            // Act  
            var result = _testData.Page(pageInfo);

            // Assert  
            ClassicAssert.AreEqual(_testData, result);
        }

        [Test]
        public void Page_InvalidPageSize_ReturnsSource()
        {
            // Arrange  
            var pageInfo = new ItemPage { Page = 1, PageSize = 0 };

            // Act  
            var result = _testData.Page(pageInfo);

            // Assert  
            ClassicAssert.AreEqual(_testData, result);
        }

        [Test]
        public void Page_ValidPageInfo_ReturnsPagedData()
        {
            // Arrange  
            var pageInfo = new ItemPage { Page = 2, PageSize = 10 };

            // Act  
            var result = _testData.Page(pageInfo).ToList();

            // Assert  
            ClassicAssert.AreEqual(10, result.Count);
            ClassicAssert.AreEqual(11, result.First());
            ClassicAssert.AreEqual(20, result.Last());
        }

        [Test]
        public void Page_PageExceedsData_ReturnsEmpty()
        {
            // Arrange  
            var pageInfo = new ItemPage { Page = 11, PageSize = 10 };

            // Act  
            var result = _testData.Page(pageInfo).ToList();

            // Assert  
            ClassicAssert.IsEmpty(result);
        }
    }
}
