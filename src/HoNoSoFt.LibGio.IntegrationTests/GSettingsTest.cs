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

        //[Fact]
        //public void ListChildren()
        //{
        //    var result = _gSettings.ListChildren();
        //    Console.WriteLine(string.Join(", ", result));
        //}

        [Fact]
        public void GetValue_ShouldReturnsTheObjectValue()
        {
            var gVariantValue = GSettings.GetValue(_schema, "list-prime-numbers");
            Assert.NotEqual(IntPtr.Zero, gVariantValue);
        }
    }
}
