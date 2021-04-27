using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Boss")] // categorize tests to order by Trait in Test Explorer
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output; // to print output in test explorer

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");

            // Arrange
            BossEnemy sut = new BossEnemy();

            // Act


            // Assert
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }


        //[Fact]
        //public void StandardName()
        //{
        //    // Arrange


        //    // Act


        //    // Assert
        //}
    }
}
