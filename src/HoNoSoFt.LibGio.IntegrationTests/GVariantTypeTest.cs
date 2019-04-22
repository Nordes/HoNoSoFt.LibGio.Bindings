using System;
using FluentAssertions;
using HoNoSoFt.LibGio.Bindings;
using HoNoSoFt.LibGio.IntegrationTests.Fixtures;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    [Trait("Category", "Integration")]
    [Collection("GSchema collection")]
    public class GVariantTypeTest : BaseTest
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
        public void GetStringLength_ShouldReturnTheTypeLength(string key, int expectedLength)
        {
            // Prepare
            var gVariant = _gSettings.GetValue(key);
            var gVariantType = gVariant.GetVariantType();
            // Execute
            var bufferSize = gVariantType.GetStringLength();
            // Verify
            bufferSize.Should().Be(expectedLength);
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
            found.Should().BeTrue();
        }

        [Fact]
        public void DupString_ShouldDuplicateTheString()
        {
            // Prepare
            var gVariant = _gSettings.GetValue("test-string");
            var gvt = gVariant.GetVariantType();
            // Execute
            var newStr = gvt.DupString();
            // Validate
            newStr.Should().Be("s");
        }

        [Theory]
        [InlineData("list-my-pets", true)]
        [InlineData("test-int", false)]
        public void IsContainer_ShouldReturnTrueWhenArray(string key, bool expectedResult)
        {
            // Prepare
            var gVariant = _gSettings.GetValue(key);
            var gvt = gVariant.GetVariantType();
            // Execute
            var isContainer = gvt.IsContainer();
            // Validate
            isContainer.Should().Be(expectedResult);
        }

        [Fact]
        public void IsContainer_ShouldReturnFalseWhenBasicType()
        {
            // Prepare
            var gVariant = _gSettings.GetValue("test-int");
            var gvt = gVariant.GetVariantType();
            // Execute
            var isContainer = gvt.IsContainer();
            // Validate
            isContainer.Should().BeFalse();
        }

        [Theory]
        [InlineData("test-int", true)]
        [InlineData("list-my-pets", false)]
        public void IsBasic_ShouldReturnTrueWhenBasicFalseWhenNot(string key, bool expectedResult)
        {
            // Prepare
            var gVariant = _gSettings.GetValue(key);
            var gvt = gVariant.GetVariantType();
            // Execute
            var isContainer = gvt.IsBasic();
            // Validate
            isContainer.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("list-my-pets", true)]
        [InlineData("test-int", false)]
        public void IsArray_ShouldReturnTrueWhenArrayAndFalseWhenNot(string key, bool expectedResult)
        {
            // Prepare
            var gVariant = _gSettings.GetValue(key);
            var gvt = gVariant.GetVariantType();
            // Execute
            var isContainer = gvt.IsArray();
            // Validate
            isContainer.Should().Be(expectedResult);
        }


        // definite/undefinite -> https://developer.gnome.org/glib/stable/glib-GVariantType.html (read top)
    }
}
