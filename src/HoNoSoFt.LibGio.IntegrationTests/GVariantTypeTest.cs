using System;
using HoNoSoFt.LibGio.Bindings;
using HoNoSoFt.LibGio.IntegrationTests.Fixtures;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    [Trait("Category", "Integration")]
    [Collection("GSchema collection")]
    public class GVariantTypeTest
    {
        private readonly IntPtr _schema;

        public GVariantTypeTest(GSchemaFixture schemaFix)
        {
            _schema = new GSettings(schemaFix.SchemaName).Settings;
        }

        [Theory]
        [InlineData("list-prime-numbers", 2)]
        [InlineData("list-my-pets", 2)]
        [InlineData("test-int", 1)]
        [InlineData("test-long", 1)]
        [InlineData("test-uint", 1)]
        [InlineData("test-uint64", 1)]
        [InlineData("current-state", 1)]
        [InlineData("my-flag-is-active", 1)]
        public void GetStringLength_ShouldReturnTheTypeLength(string key, int length)
        {
            // Prepare
            var gVariantValue = GSettings.GetValue(_schema, key);
            var variantType = GVariant.GetType(gVariantValue);
            // Execute
            var bufferSize = GVariantType.GetStringLength(variantType);
            // Verify
            Assert.Equal(length, bufferSize);
        }

        [Fact]
        public void New_ShouldCreateANewInstanceOfGVariantType()
        {
            // Prepare
            string typeString = "ai";
            // Execute
            var gVariantTypeIntPtr = GVariantType.New(typeString);
            // Verify
            Assert.True(gVariantTypeIntPtr.ToInt64() > 0);
        }
    }
}
