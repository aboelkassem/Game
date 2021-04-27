using Xunit;

namespace GameEngine.Tests
{
    [CollectionDefinition("GameState collection")]
    // this class used for share the same instance between multiple test classes and it's methods,
    // not only method in one class but must have the same [CollectionDefinition] attribute name,
    // and used in targets classes [Collection] attribute
    // Also must have GameStateFixture
    public class GameStateCollection : ICollectionFixture<GameStateFixture>
    {
    }
}
