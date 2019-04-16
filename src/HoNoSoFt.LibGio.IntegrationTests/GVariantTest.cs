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
            _schema = new GSettings(schemaFix.SchemaName).GSettingsPtr;
        }

        [Theory]
        [InlineData("list-prime-numbers", "ai")]
        [InlineData("list-my-pets", "as")]
        [InlineData("test-int", "i")]
        [InlineData("test-long", "x")]
        [InlineData("test-uint", "u")]
        [InlineData("test-uint64", "t")]
        [InlineData("test-double", "d")]
        [InlineData("test-string", "s")]
        [InlineData("current-state", "s")]
        [InlineData("my-flag-is-active", "b")]
        public void GetType_ShouldReturnsTheObjectType(string key, string gVariantTypeString)
        {
            // Prepare
            var gVariantValue = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var variantType = Bindings.PInvokes.GVariant.GetType(gVariantValue);
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
        [InlineData("test-double", "d")]
        [InlineData("test-string", "s")]
        [InlineData("current-state", "s")]
        [InlineData("my-flag-is-active", "b")]
        public void GetTypeString_ShouldReturnsTheObjectType(string key, string gVariantTypeString)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var typeAsString = gVariant.GetTypeString();
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
        [InlineData("test-double", "d")]
        [InlineData("test-string", "s")]
        [InlineData("current-state", "s")]
        [InlineData("my-flag-is-active", "b")]
        public void IsOfType_ShouldLookForEqualTypeSuccessfully(string key, string expectedType)
        {
            // Prepare
            var gVariantType = new GVariantType(expectedType);
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var result = gVariant.IsOfType(gVariantType);
            // Verify
            Assert.True(result);
        }

        [Theory]
        [InlineData("list-prime-numbers")]
        [InlineData("list-my-pets")]
        public void IsContainer_ShouldReturnsTrueIfContainer(string key)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var result = gVariant.IsContainer();
            // Assert
            Assert.True(result);
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
        public void IsContainer_ShouldReturnsFalseIfNotContainer(string key)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var result = gVariant.IsContainer();
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("test-int", "G_VARIANT_CLASS_INT32")]
        [InlineData("test-long", "G_VARIANT_CLASS_INT64")]
        [InlineData("test-uint", "G_VARIANT_CLASS_UINT32")]
        [InlineData("test-uint64", "G_VARIANT_CLASS_UINT64")]
        [InlineData("test-double", "G_VARIANT_CLASS_DOUBLE")]
        [InlineData("test-string", "G_VARIANT_CLASS_STRING")]
        [InlineData("current-state", "G_VARIANT_CLASS_STRING")]
        [InlineData("my-flag-is-active", "G_VARIANT_CLASS_BOOLEAN")]
        [InlineData("list-prime-numbers", "G_VARIANT_CLASS_ARRAY")]
        public void Classify_ShouldSucceed(string key, string mainClassName)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var result = gVariant.Classify();
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
        [InlineData("test-double", "3.1415999999999999")]
        [InlineData("test-string", "'Captain Morgan'")]
        [InlineData("current-state", "'off'")]
        [InlineData("my-flag-is-active", "true")]
        public void Print_ShouldRetrieveTheDataTypeAnnotateWithSuccess(string key, string prettyPrint)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var content = gVariant.Print(true);
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
        [InlineData("test-double", "3.1415999999999999")]
        [InlineData("test-string", "'Captain Morgan'")]
        [InlineData("current-state", "'off'")]
        [InlineData("my-flag-is-active", "true")]
        public void Print_ShouldRetrieveTheDataNoTypeAnnotateWithSuccess(string key, string prettyPrint)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var content = gVariant.Print(false);
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
        [InlineData("test-double", "3.1415999999999999")]
        [InlineData("test-string", "'Captain Morgan'")]
        [InlineData("current-state", "'off'")]
        [InlineData("my-flag-is-active", "true")]
        public void PrintString_ShouldReturnOnlyValue(string key, string prettyPrint)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var result = gVariant.PrintString(null, false);
            // Verify
            Assert.Equal(prettyPrint, result);
        }

        [Theory]
        [InlineData("list-prime-numbers", "Hello [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43]")]
        [InlineData("list-my-pets", "Hello ['Captain', 'Scrooge', 'Mana', 'Saturn', 'Brutal']")]
        [InlineData("test-int", "Hello 50")]
        [InlineData("test-long", "Hello 9223372036854775807")]
        [InlineData("test-uint", "Hello 4294967295")]
        [InlineData("test-uint64", "Hello 18446744073709551615")]
        [InlineData("test-double", "Hello 3.1415999999999999")]
        [InlineData("test-string", "Hello 'Captain Morgan'")]
        [InlineData("current-state", "Hello 'off'")]
        [InlineData("my-flag-is-active", "Hello true")]
        public void PrintString_ShouldReturnPrefixAndValue(string key, string prettyPrint)
        {
            // Prepare
            var gVariantPtr = Bindings.PInvokes.GSettings.GetValue(_schema, key);
            // Execute
            var gVariant = new GVariant(gVariantPtr);
            var result = gVariant.PrintString("Hello ", false);
            // Verify
            Assert.Equal(prettyPrint, result);
        }
    }
}
