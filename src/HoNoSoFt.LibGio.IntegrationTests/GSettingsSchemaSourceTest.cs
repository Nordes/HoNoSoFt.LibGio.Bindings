using HoNoSoFt.LibGio.Bindings;
using HoNoSoFt.LibGio.Bindings.Exceptions;
using HoNoSoFt.LibGio.Bindings.GStructs;
using System;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    public class GSettingsSchemaSourceTest : BaseTest
    {
        [Fact(Skip = "Sometimes fail")]
        public void Ctor_ShouldThrowWhenDirectoryNotFound()
        {
            var expected = new GError(
                75,
                4,
                "Failed to open file “/tmp/doesNotExists/gschemas.compiled”: open() failed: No such file or directory");

            var ex = Assert.Throws<GSettingsSchemaSourceException>(() => new GSettingsSchemaSource("/tmp/doesNotExists", null, true));

            Assert.Equal(expected.code, ex.Details.code);
            Assert.Equal(expected.domain, ex.Details.domain);
            Assert.Equal(expected.message, ex.Details.message);
        }

        [Fact]
        public void Ctor_ShouldSucceedWhenDirectoryFound()
        {
            // prepare
            var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            // Execute
            var result = new GSettingsSchemaSource($"{homePath}/schemas/", null, true);
            // Asser
            Assert.NotEqual(IntPtr.Zero, result.GSettingsSchemaSourcePtr);
        }

        [Fact]
        public void ListSchemas_ShouldReturnAllSchemas()
        {
            // prepare
            var schemaSource = new GSettingsSchemaSource();
            // Execute
            var schemas = schemaSource.ListSchemas(false);

            // Assert
            // Non relocatable:
            //  [com.honosoft.integration.with.path.book]
            //  [com.honosoft.integration.with.path]
            // Relocatable:
            //  [Empty]
            Assert.Equal(2, schemas.NonRelocatable.Count);
            Assert.Empty(schemas.Relocatable);
        }
    }
}
