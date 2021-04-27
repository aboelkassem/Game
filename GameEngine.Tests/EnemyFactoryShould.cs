using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie");

            // Assert
            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie");

            // Assert
            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy); // if IsType passed, it return the object
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparateInstances()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            // Assert
            //Assert.Same(enemy1, enemy2); //  if equal to the same reference
            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowName()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Create(null)); // this expecting throwing an exception
            //Assert.Throws<ArgumentNullException>("name", () => sut.Create(null)); //name: is the paramaterName in the method that would the exception happen
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act

            // Assert
            // Exception because not ends with King or Queen like "Zombie King"
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
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
