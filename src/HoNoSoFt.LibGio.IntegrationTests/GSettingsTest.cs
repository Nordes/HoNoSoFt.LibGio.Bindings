using System;
using HoNoSoFt.LibGio.Bindings;
using HoNoSoFt.LibGio.IntegrationTests.Assets.Models;
using HoNoSoFt.LibGio.IntegrationTests.Fixtures;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    [Trait("Category", "Integration")]
    [Collection("GSchema collection")]
    public class GSettingsTest
    {
        private readonly GSchemaFixture _schemaFix;
        private readonly IntPtr _schema;
        private readonly GSettings _gSettings;

        public GSettingsTest(GSchemaFixture schemaFix)
        {
            _schemaFix = schemaFix;
            _gSettings = new GSettings(_schemaFix.SchemaName);
            _schema = _gSettings.Settings;
        }

        [Fact]
        public void New_ShouldReturnsSchemaPointer()
        {
            var settings = new GSettings(_schemaFix.SchemaName);
            Assert.NotEqual(IntPtr.Zero, settings.Settings);
        }

        [Fact]
        public void GetInt_ShouldReturnTheIntValue()
        {
            // Execute
            var result = _gSettings.GetInt("test-int");
            // Assert
            Assert.Equal(50, result);
        }

        [Fact]
        public void SetInt_ShouldReturnTheIntValue()
        {
            // Prepare
            var expectedValue = 22;
            // Execute
            var result = _gSettings.SetInt("test-int", expectedValue);
            var resultUpdated = _gSettings.GetInt("test-int");
            // Assert
            Assert.True(result);
            Assert.Equal(expectedValue, resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("test-int");
        }

        [Fact]
        public void GetInt64_ShouldReturnTheIntValue()
        {
            // Execute
            var result = _gSettings.GetInt64("test-long");
            // Assert
            Assert.Equal(long.MaxValue, result);
        }

        [Fact]
        public void GetUInt_ShouldReturnTheIntValue()
        {
            // Execute
            var result = _gSettings.GetUInt("test-uint");
            // Assert
            Assert.Equal(uint.MaxValue, result);
        }

        [Fact]
        public void GetUInt64_ShouldReturnTheIntValue()
        {
            // Execute
            var result = _gSettings.GetUInt64("test-uint64");
            // Assert
            Assert.Equal(ulong.MaxValue, result);
        }

        [Fact]
        public void GetBoolean_ShouldReturnTheBooleanValue()
        {
            // Execute
            var result = _gSettings.GetBoolean("my-flag-is-active");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetFlags_ShouldReturnsTheFlags()
        {
            var result = (MyFlags) _gSettings.GetFlags("test-flags");

            Assert.False(result.HasFlag(MyFlags.Flag1));
            Assert.True(result.HasFlag(MyFlags.Flag2));
            Assert.True(result.HasFlag(MyFlags.Flag3));
        }

        [Fact]
        public void ListKeys()
        {
            // Prepare
            var expected ="list-my-pets, test-uint, test-long, test-flags, current-state, my-flag-is-active, " +
                          "test-int, test-uint64, list-prime-numbers";
            //Execute
            var result = _gSettings.ListKeys();
            // Validate
            Assert.Equal(expected, string.Join(", ", result));
        }

        [Fact]
        public void GetValue_ShouldReturnsTheObjectValue()
        {
            var gVariantValue = GSettings.GetValue(_schema, "list-prime-numbers");
            Assert.NotEqual(IntPtr.Zero, gVariantValue);
        }
    }
}
