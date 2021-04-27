using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Tests
{
    // This class for sharing once through all test methods (will use the same one for each test method)
    // not creating every instance from it
    public class GameStateFixture : IDisposable
    {
        public GameState State { get; private set; }

        public GameStateFixture()
        {
            State = new GameState();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}
