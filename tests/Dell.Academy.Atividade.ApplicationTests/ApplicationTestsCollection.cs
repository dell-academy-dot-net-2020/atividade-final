using Xunit;

namespace Dell.Academy.Atividade.ApplicationTests
{
    [CollectionDefinition(nameof(ApplicationTestsCollection))]
    public class ApplicationTestsCollection : ICollectionFixture<ApplicationTestsFixture>
    {
    }
}