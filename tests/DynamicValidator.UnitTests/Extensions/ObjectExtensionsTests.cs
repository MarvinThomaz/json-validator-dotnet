using Xunit;
using System;

namespace DynamicValidator.UnitTests.Extensions
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void SuccessVerifyIntIsNumber()
        {
            const int value = 1;

            var result = value.IsNumber();

            Assert.True(result);
        }

        [Fact]
        public void SuccessVerifyIntIsShort()
        {
            const short value = 1;

            var result = value.IsNumber();

            Assert.True(result);
        }

        [Fact]
        public void SuccessVerifyIntIsLong()
        {
            const long value = 1;

            var result = value.IsNumber();

            Assert.True(result);
        }

        [Fact]
        public void SuccessVerifyIntIsDouble()
        {
            const double value = 1;

            var result = value.IsNumber();

            Assert.True(result);
        }

        [Fact]
        public void SuccessVerifyIntIsFloat()
        {
            const float value = 1;

            var result = value.IsNumber();

            Assert.True(result);
        }

        [Fact]
        public void SuccessVerifyIntIsDecimal()
        {
            const decimal value = 1;

            var result = value.IsNumber();

            Assert.True(result);
        }

        [Theory()]
        [InlineData("value")]
        [InlineData(null)]
        [InlineData(true)]
        public void FailedToVerifyValueIsNumber(object value)
        {
            var result = value.IsNumber();

            Assert.False(result);
        }

        [Fact]
        public void SuccessCastIntIsNumber()
        {
            const int value = 1;

            var result = value.ToNumber();

            Assert.Equal(value, result);
        }

        [Fact]
        public void SuccessCastIntIsShort()
        {
            const short value = 1;

            var result = value.ToNumber();

            Assert.Equal(value, result);
        }

        [Fact]
        public void SuccessCastIntIsLong()
        {
            const long value = 1;

            var result = value.ToNumber();

            Assert.Equal(value, result);
        }

        [Fact]
        public void SuccessCastIntIsDouble()
        {
            const double value = 1.1;

            var result = value.ToNumber();

            Assert.Equal(value, (double)result);
        }

        [Fact]
        public void SuccessCastIntIsFloat()
        {
            const float value = 1.1F;

            var result = value.ToNumber();

            Assert.Equal(value, (float)result);
        }

        [Fact]
        public void SuccessCastIntIsDecimal()
        {
            const decimal value = 1.1M;

            var result = value.ToNumber();

            Assert.Equal(value, result);
        }

        [Theory()]
        [InlineData("value")]
        [InlineData(null)]
        [InlineData(true)]
        public void FailedToCastValueIsNumber(object value)
        {
            var result = value.ToNumber();

            Assert.NotEqual(value, result);
            Assert.Equal(0, result);
        }
    }
}