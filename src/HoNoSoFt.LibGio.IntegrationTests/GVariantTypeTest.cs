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
        private readonly GSettings _gSettings;

        public GVariantTypeTest(GSchemaFixture schemaFix)
        {
            _gSettings = new GSettings(schemaFix.SchemaName);
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
            var gVariant = _gSettings.GetValue(key);
            var gVariantType = gVariant.GetVariantType();
            // Execute
            var bufferSize = gVariantType.GetStringLength();
            // Verify
            Assert.Equal(length, bufferSize);
        }

        [Fact]
        public void New_ShouldCreateANewInstanceOfGVariantType()
        {
            // Prepare
            string typeString = "ai";
            // Execute
            var gVariantTypeArrayInt = new GVariantType(typeString);
            // Verify
            Assert.True(gVariantTypeArrayInt.GVariantTypePtr != IntPtr.Zero);
        }

        [Fact]
        public void StringScan_ShouldReturnTrueIfFound()
        {
            // Prepare
            var gVariant = _gSettings.GetValue("test-string");
            var gvt = gVariant.GetVariantType();
            // Execute
            var found = gvt.StringScan("s");
            // Validate
            Assert.True(found);
        }
    }
}
