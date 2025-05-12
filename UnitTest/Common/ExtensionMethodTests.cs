using NUnit.Framework.Legacy;
using Utilities.ExtensionMethod;

namespace UnitTest.Common
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void ValidateValue_StringIsNull_ThrowsInvalidOperationException()
        {
            string? value = null;
            var ex = Assert.Throws<InvalidOperationException>(() => value.ValidateValue());
            Assert.That(ex.Message, Does.Contain("is invalid"));
        }

        [Test]
        public void ValidateValue_StringIsNotNull_ReturnsValue()
        {
            string value = "Test";
            var result = value.ValidateValue();
            ClassicAssert.AreEqual(value, result);
        }

        [Test]
        public void ValidateValue_NullableIntIsNull_ThrowsInvalidOperationException()
        {
            int? value = null;
            var ex = Assert.Throws<InvalidOperationException>(() => value.ValidateValue());
            ClassicAssert.That(ex.Message, Does.Contain("is invalid"));
        }

        [Test]
        public void ValidateValue_NullableIntIsNotNull_ReturnsValue()
        {
            int? value = 5;
            var result = value.ValidateValue();
            ClassicAssert.AreEqual(5, result);
        }

        [Test]
        public void IsNotNull_ObjectIsNull_ReturnsFalse()
        {
            object? obj = null;
            var result = obj.IsNotNull();
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void IsNotNull_ObjectIsNotNull_ReturnsTrue()
        {
            object obj = new object();
            var result = obj.IsNotNull();
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void Encript_ValidString_ReturnsBase64EncodedString()
        {
            string data = "Test";
            var result = data.Encript();
            ClassicAssert.AreEqual("VGVzdA==", result);
        }

        [Test]
        public void ToEnum_ValidEnumString_ReturnsEnumValue()
        {
            string value = "Monday";
            var result = value.ToEnum<DayOfWeek>();
            ClassicAssert.AreEqual(DayOfWeek.Monday, result);
        }

        [Test]
        public void ToEnum_InvalidEnumString_ReturnsFirstEnumValue()
        {
            string value = "InvalidValue";
            var result = value.ToEnum<DayOfWeek>();
            ClassicAssert.AreEqual(DayOfWeek.Sunday, result);
        }
    }
}
