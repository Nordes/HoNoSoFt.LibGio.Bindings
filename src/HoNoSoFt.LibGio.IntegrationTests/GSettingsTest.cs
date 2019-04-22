using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HoNoSoFt.LibGio.Bindings;
using HoNoSoFt.LibGio.IntegrationTests.Assets.Models;
using HoNoSoFt.LibGio.IntegrationTests.Fixtures;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    [Trait("Category", "Integration")]
    [Collection("GSchema collection")]
    public class GSettingsTest : BaseTest
    {
        private readonly GSchemaFixture _schemaFix;
        private readonly GSettings _gSettings;

        public GSettingsTest(GSchemaFixture schemaFix)
        {
            _schemaFix = schemaFix;
            _gSettings = new GSettings(_schemaFix.SchemaName);
        }

        [Fact]
        public void New_ShouldReturnsSchemaPointer()
        {
            var settings = new GSettings(_schemaFix.SchemaName);
            Assert.NotEqual(IntPtr.Zero, settings.GSettingsPtr);
        }

        [Fact]
        public void Sync_ShouldCommitAll()
        {
            // Prepare
            // Execute
            GSettings.Sync();
            // Assert
            // Should simply not fail.
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
        public void SetBoolean_ShouldReturnTheBooleanValue()
        {
            // Prepare
            // Execute
            var result = _gSettings.SetBoolean("my-flag-is-active", false);
            var resultUpdated = _gSettings.GetBoolean("my-flag-is-active");
            // Assert
            Assert.True(result);
            Assert.False(resultUpdated);
            // Reset the value to it's original state.
            _gSettings.Reset("my-flag-is-active");
        }

        [Fact]
        public void GetDouble_ShouldReturnTheDoubleValue()
        {
            // Execute
            var result = _gSettings.GetDouble("test-double");
            // Assert
            Assert.Equal(3.1415999999999999, result);
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
            var result = (MyFlags)_gSettings.GetFlags("test-flags");

            Assert.False(result.HasFlag(MyFlags.Flag1));
            Assert.True(result.HasFlag(MyFlags.Flag2));
            Assert.True(result.HasFlag(MyFlags.Flag3));
        }

        [Fact]
        public void ListKeys_ShouldReturnsAllTheKeys()
        {
            // Prepare
            var expected = "list-my-pets, test-string, test-long, test-uint, test-flags, current-state, my-flag-is-active, " +
                           "test-int, test-uint64, list-prime-numbers, test-double";
            //Execute
#pragma warning disable 618
            var result = _gSettings.ListKeys();
#pragma warning restore 618
            // Validate
            Assert.Equal(expected, string.Join(", ", result));
        }

        [Fact]
        public void SetValue_ShouldUpdateTheValueWithSuccess()
        {
            // Prepare
            const int expectedNewValue = 42;
            var gv = new GVariant(expectedNewValue);
            // Execute
            var result = _gSettings.SetValue("test-int", gv);
            var newValue = _gSettings.GetInt("test-int");
            // Validate
            Assert.True(result);
            Assert.Equal(expectedNewValue, newValue);
            // Reset the value for next tests
            _gSettings.Reset("test-int");
        }

        [Theory]
        [InlineData("test-int")]
        [InlineData("test-long")]
        [InlineData("test-uint")]
        [InlineData("test-uint64")]
        [InlineData("test-double")]
        [InlineData("test-string")]
        [InlineData("current-state")]
        [InlineData("my-flag-is-active")]
        public void IsWritable_ShouldReturnIfWritable(string key)
        {
            // Prepare
            // Execute
            var isWritable = _gSettings.IsWritable(key);
            // Validate
            Assert.True(isWritable);
        }

        [Theory]
        [InlineData("best-book")]
        public void GetChild_ShouldReturnExistingChild(string childName)
        {
            // Prepare
            // Execute
            var gs = _gSettings.GetChild(childName);
#pragma warning disable 618
            var keys = gs.ListKeys();
#pragma warning restore 618
            // Validate
            Assert.NotNull(gs);
            Assert.NotNull(keys);
            Assert.Equal(2, keys.Count);
        }

        [Fact]
        public void GetUserValue_ShouldReturnCurrentUserValue()
        {
            // Prepare
            const int userValue = 42;
            // Execute
            _gSettings.SetInt("test-int", userValue);
            var gvUserValue = _gSettings.GetUserValue("test-int");
            var result = gvUserValue.GetInt();
            // Validate
            Assert.Equal(userValue, result);
            // Reset the value for next tests
            _gSettings.Reset("test-int");
        }

        [Fact]
        public void GetDefaultValue_ShouldReturnCurrentUserValue()
        {
            // Prepare
            const int userValue = 42;
            // Execute
            _gSettings.SetInt("test-int", userValue);
            var gvUserValue = _gSettings.GetUserValue("test-int");
            var userFinalValue = gvUserValue.GetInt();
            var gvDefaultValue = _gSettings.GetDefaultValue("test-int");
            var defaultValue = gvDefaultValue.GetInt();
            // Validate
            Assert.NotEqual(userFinalValue, defaultValue);
            Assert.Equal(50, defaultValue);
            Assert.Equal(userValue, userFinalValue);
            // Reset the value for next tests
            _gSettings.Reset("test-int");
        }

        [Fact]
        public void GetStringV_ShouldReturnArrayOfString()
        {
            // Prepare
            // Execute
            var pets = _gSettings.GetStringV("list-my-pets");
            // Validate
            Assert.Equal(5, pets.Count);
            Assert.Equal("Captain", pets.First());
            Assert.Equal("Brutal", pets.Last());
        }

        [Fact]
        public void SetStringV_ShouldSetNewArrayOfString()
        {
            // Prepare
            var newValues = new List<string> { "Waldo", "Willy", "Wonka" };
            // Execute
            var successToChangeValue = _gSettings.SetStringV("list-my-pets", newValues);
            var pets = _gSettings.GetStringV("list-my-pets");
            // Assert
            successToChangeValue.Should().Be(true, "Without being true, it means it was not able to update the schema");
            pets.Should().BeEquivalentTo(newValues);
            // Reset value
            _gSettings.Reset("list-my-pets");
        }

        [Fact]
        public void SetStringV_ShouldSetEmptyArrayOfStringWhenNull()
        {
            // Prepare
            // Execute
            var successToChangeValue = _gSettings.SetStringV("list-my-pets", null);
            var pets = _gSettings.GetStringV("list-my-pets");
            // Assert
            successToChangeValue.Should().Be(true, "Without being true, it means it was not able to update the schema");
            pets.Should().BeEquivalentTo(new List<string>());
            // Reset value
            _gSettings.Reset("list-my-pets");
        }


        [Fact]
        public void GetEnum_ShouldReturnEnumValues()
        {
            // Prepare
            // Execute
            var state = _gSettings.GetEnum("current-state");
            // Validate
            Assert.Equal(1, state);
        }

        [Fact]
        public void SetEnum_ShouldUpdateEnumValues()
        {
            // Prepare
            // Execute
            var succeeded = _gSettings.SetEnum("current-state", 2);
            var state = _gSettings.GetEnum("current-state");
            // Validate
            Assert.True(succeeded);
            Assert.Equal(2, state);
            // Reset the value for next tests
            _gSettings.Reset("current-state");
        }

        [Fact]
        public void GetFlags_ShouldReturnFlagsValues()
        {
            // Prepare
            // Execute
            var flags = _gSettings.GetFlags("test-flags");
            // Validate
            Assert.Equal((uint)6, flags);
        }

        [Fact]
        public void SetFlags_ShouldUpdateFlagsValues()
        {
            // Prepare
            // Execute
            var succeeded = _gSettings.SetFlags("test-flags", 7);
            var flags = _gSettings.GetFlags("test-flags");
            // Validate
            Assert.True(succeeded);
            Assert.Equal((uint)7, flags);
            // Reset the value for next tests
            _gSettings.Reset("test-flags");
        }
    }
}
