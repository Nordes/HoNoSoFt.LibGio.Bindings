using System;
using System.Runtime.InteropServices;
using HoNoSoFt.LibGio.Bindings;
using HoNoSoFt.LibGio.IntegrationTests.Fixtures;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    [Trait("Category", "Integration")]
    [Collection("GSchema collection")]
    public class GVariantTest
    {
        private readonly IntPtr _schema;

        public GVariantTest(GSchemaFixture schemaFix)
        {
            _schema = new GSettings(schemaFix.SchemaName).Settings;
        }

        [Theory]
        [InlineData("list-prime-numbers", "ai")]
        [InlineData("list-my-pets", "as")]
        [InlineData("test-int", "i")]
        [InlineData("test-long", "x")]
        [InlineData("test-uint", "u")]
        [InlineData("test-uint64", "t")]
        [InlineData("current-state", "s")]
        [InlineData("my-flag-is-active", "b")]
        public void GetType_ShouldReturnsTheObjectType(string key, string gVariantTypeString)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var variantType = GVariant.GetType(gVariantValue);
            var typeAsString = Bindings.PInvokes.GVariantType.TypePeekString(variantType);
            // Verify
            Assert.Equal(gVariantTypeString, typeAsString);
        }

        [Theory]
        // E.g.: ai = int[]
        [InlineData("list-prime-numbers", "ai")]
        [InlineData("list-my-pets", "as")]
        [InlineData("test-int", "i")]
        [InlineData("test-long", "x")]
        [InlineData("test-uint", "u")]
        [InlineData("test-uint64", "t")]
        [InlineData("current-state", "s")]
        [InlineData("my-flag-is-active", "b")]
        public void GetTypeString_ShouldReturnsTheObjectType(string key, string gVariantTypeString)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var typeAsStringPtr = GVariant.GetTypeString(gVariantValue);
            var typeAsString = Marshal.PtrToStringAnsi(typeAsStringPtr);
            // Verify
            Assert.Equal(gVariantTypeString, typeAsString);
        }

        [Theory]
        [InlineData("list-prime-numbers", "ai")]
        [InlineData("list-my-pets", "as")]
        [InlineData("test-int", "i")]
        [InlineData("test-long", "x")]
        [InlineData("test-uint", "u")]
        [InlineData("test-uint64", "t")]
        [InlineData("current-state", "s")]
        [InlineData("my-flag-is-active", "b")]
        public void IsOfType_ShouldLookForEqualTypeSuccessfully(string key, string expectedType)
        {
            // Prepare
            var gVariantTypeIntPtr = Bindings.PInvokes.GVariantType.New(expectedType);
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var result = GVariant.IsOfType(gVariantValue, gVariantTypeIntPtr);
            // Verify
            Assert.True(result);
        }

        [Theory]
        [InlineData("list-prime-numbers")]
        [InlineData("list-my-pets")]
        public void IsContainer_ShouldReturnsTrueIfContainer(string key)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var result = GVariant.IsContainer(gVariantValue);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("test-int")]
        [InlineData("test-long")]
        [InlineData("test-uint")]
        [InlineData("test-uint64")]
        [InlineData("current-state")]
        [InlineData("my-flag-is-active")]
        public void IsContainer_ShouldReturnsFalseIfNotContainer(string key)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var result = GVariant.IsContainer(gVariantValue);
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("test-int", "G_VARIANT_CLASS_INT32")]
        [InlineData("test-long", "G_VARIANT_CLASS_INT64")]
        [InlineData("test-uint", "G_VARIANT_CLASS_UINT32")]
        [InlineData("test-uint64", "G_VARIANT_CLASS_UINT64")]
        [InlineData("current-state", "G_VARIANT_CLASS_STRING")]
        [InlineData("my-flag-is-active", "G_VARIANT_CLASS_BOOLEAN")]
        [InlineData("list-prime-numbers", "G_VARIANT_CLASS_ARRAY")]
        public void Classify_ShouldSucceed(string key, string mainClassName)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            var result = GVariant.Classify(gVariantValue);
            // Verify
            Assert.Equal(mainClassName, result.ToString());
        }

        [Theory]
        [InlineData("list-prime-numbers", "[2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43]")]
        [InlineData("list-my-pets", "['Captain', 'Scrooge', 'Mana', 'Saturn', 'Brutal']")]
        [InlineData("test-int", "50")]
        [InlineData("test-long", "int64 9223372036854775807")]
        [InlineData("test-uint", "uint32 4294967295")]
        [InlineData("test-uint64", "uint64 18446744073709551615")]
        [InlineData("current-state", "'off'")]
        [InlineData("my-flag-is-active", "true")]
        public void Print_ShouldRetrieveTheDataTypeAnnotateWithSuccess(string key, string prettyPrint)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var content = GVariant.Print(gVariantValue, true);
            // Verify
            Assert.Equal(prettyPrint, content);
        }

        [Theory]
        [InlineData("list-prime-numbers", "[2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43]")]
        [InlineData("list-my-pets", "['Captain', 'Scrooge', 'Mana', 'Saturn', 'Brutal']")]
        [InlineData("test-int", "50")]
        [InlineData("test-long", "9223372036854775807")]
        [InlineData("test-uint", "4294967295")]
        [InlineData("test-uint64", "18446744073709551615")]
        [InlineData("current-state", "'off'")]
        [InlineData("my-flag-is-active", "true")]
        public void Print_ShouldRetrieveTheDataNoTypeAnnotateWithSuccess(string key, string prettyPrint)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var content = GVariant.Print(gVariantValue, false);
            // Verify
            Assert.Equal(prettyPrint, content);
        }
    }
}
