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
            _schema = _gSettings.GSettingsPtr;
        }

        [Fact]
        public void New_ShouldReturnsSchemaPointer()
        {
            var settings = new GSettings(_schemaFix.SchemaName);
            Assert.NotEqual(IntPtr.Zero, settings.GSettingsPtr);
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
        public void SetInt_ShouldSetNewValue()
        {
            // Prepare
            var expectedValue = -22;
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
        public void GetDouble_ShouldReturnTheDoubleValue()
        {
            // Execute
            var result = _gSettings.GetDouble("test-double");
            // Assert
            Assert.Equal((double)3.1415999999999999, result);
        }

        [Fact]
        public void SetDouble_ShouldSetNewValue()
        {
            // Prepare
            var expectedValue = 4.1415999999999999;
            // Execute
            var result = _gSettings.SetDouble("test-double", expectedValue);
            var resultUpdated = _gSettings.GetDouble("test-double");
            // Assert
            Assert.True(result);
            Assert.Equal(expectedValue, resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("test-double");
        }

        [Fact]
        public void GetString_ShouldReturnTheStringValue()
        {
            // Execute
            var result = _gSettings.GetString("test-string");
            // Assert
            Assert.Equal("Captain Morgan", result);
        }

        [Fact]
        public void SetString_ShouldSetNewValue()
        {
            // Prepare
            var expectedValue = "Havana Club";
            // Execute
            var result = _gSettings.SetString("test-string", expectedValue);
            var resultUpdated = _gSettings.GetString("test-string");
            // Assert
            Assert.True(result);
            Assert.Equal(expectedValue, resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("test-string");
        }

        [Fact]
        public void SetUInt_ShouldSetNewValue()
        {
            // Prepare
            var expectedValue = (uint)22;
            // Execute
            var result = _gSettings.SetUInt("test-uint", expectedValue);
            var resultUpdated = _gSettings.GetUInt("test-uint");
            // Assert
            Assert.True(result);
            Assert.Equal(expectedValue, resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("test-uint");
        }

        [Fact]
        public void SetInt64_ShouldSetNewValue()
        {
            // Prepare
            var expectedValue = 9223372036854775805;
            // Execute
            var result = _gSettings.SetInt64("test-long", expectedValue);
            var resultUpdated = _gSettings.GetInt64("test-long");
            // Assert
            Assert.True(result);
            Assert.Equal(expectedValue, resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("test-long");
        }

        [Fact]
        public void SetUInt64_ShouldSetNewValue()
        {
            // Prepare
            var expectedValue = 18446744073709551614;
            // Execute
            var result = _gSettings.SetUInt64("test-uint64", expectedValue);
            var resultUpdated = _gSettings.GetUInt64("test-uint64");
            // Assert
            Assert.True(result);
            Assert.Equal(expectedValue, resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("test-uint64");
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
            var expected = "list-my-pets, test-string, test-long, test-uint, test-flags, current-state, my-flag-is-active, " +
                           "test-int, test-uint64, list-prime-numbers, test-double";
            //Execute
            var result = _gSettings.ListKeys();
            // Validate
            Assert.Equal(expected, string.Join(", ", result));
        }

        //[Fact]
        //public void GetValue_ShouldReturnsTheObjectValue()
        //{
        //    throw new NotImplementedException("Not fully implemented, see GSettings.GetValue");
        //    var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, "list-prime-numbers");
        //    Assert.NotEqual(IntPtr.Zero, gVariantValue);
        //}
    }
}
