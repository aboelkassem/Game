using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category","GameState")]
    // IClassFixture<TFixture>: is telling xUnit that this class will create before first test executed
    // and disposed after all test methods have executed
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");

            // Arrange

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            // Act
            _gameStateFixture.State.Earthquake();

            // Assert
            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");

            // Arrange

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            // Act
            _gameStateFixture.State.Reset();

            // Assert
            Assert.Empty(_gameStateFixture.State.Players);
        }
    }
}
