using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests.Fixtures
{
    [CollectionDefinition("GSchema collection")]
    public class GSchemaCollection: ICollectionFixture<GSchemaFixture>
    {
        // Ref: https://xunit.github.io/docs/shared-context
    }
}
