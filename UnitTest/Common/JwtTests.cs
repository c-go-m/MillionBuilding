using NUnit.Framework.Legacy;
using Utilities.Jwt;
using Utilities.Utilities;

namespace UnitTest.Common
{
    [TestFixture]
    public class JwtTests
    {
        [SetUp]
        public void Setup()
        {
            Environment.SetEnvironmentVariable(ConstantsConfig.JwtIssuer, "TestIssuer");
            Environment.SetEnvironmentVariable(ConstantsConfig.JwtAudience, "TestAudience");
            Environment.SetEnvironmentVariable(ConstantsConfig.JwtKey, "TestKey123456789012345678901234567890");
            Environment.SetEnvironmentVariable(ConstantsConfig.JwtExpire, "60");
        }


        [Test]
        public void GenerateToken_ReturnsToken()
        {
            // Arrange              
            string userName = "TestUser";

            // Act  
            string token = Jwt.GenerateToken(userName);

            // Assert  
            ClassicAssert.IsNotNull(token);
            ClassicAssert.IsNotEmpty(token);
        }        
    }
}
