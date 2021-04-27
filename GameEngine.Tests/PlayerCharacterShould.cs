using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "PlayerCharacter")] // categorize tests to order by Trait in Test Explorer
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;

        // the constructor will executed for every test method,
        // because each test method create a separate class instance
        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            // Arrange

            // sut = system under test => track what's being tested by this test method
            //PlayerCharacter sut = new PlayerCharacter();


            // Act

            // Assert
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            // Arrange
            _sut.FirstName = "Mohamed";
            _sut.LastName = "Aboelkassem";

            // Act

            // Assert
            Assert.Equal("Mohamed Aboelkassem", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            // Arrange
            _sut.FirstName = "Mohamed";
            _sut.LastName = "Aboelkassem";

            // Act

            // Assert
            Assert.StartsWith("Mohamed", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithFirstName()
        {
            // Arrange
            _sut.FirstName = "Mohamed";
            _sut.LastName = "Aboelkassem";

            // Act

            // Assert
            Assert.EndsWith("Aboelkassem", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            // Arrange
            _sut.FirstName = "MOHAMED";
            _sut.LastName = "ABOELKASSEM";

            // Act

            // Assert
            Assert.Equal("Mohamed Aboelkassem", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Arrange
            _sut.FirstName = "Mohamed";
            _sut.LastName = "Aboelkassem";

            // Act

            // Assert
            Assert.Contains("ed Ab", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            // Arrange
            _sut.FirstName = "Mohamed";
            _sut.LastName = "Aboelkassem";

            // Act

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            // Arrange

            // Act

            // Assert
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            // Arrange

            // Act
            _sut.Sleep();

            // Assert
            //Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            // Arrange

            // Act

            // Assert
            //Assert.NotNull(_sut.Nickname);
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBowWeapon()
        {
            // Arrange

            // Act

            // Assert
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonderWeapon()
        {
            // Arrange

            // Act

            // Assert
            Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKingOfSwordWeapon()
        {
            // Arrange

            // Act

            // Assert
            // check if the list (weapons) matches the predicate (one of them contains a substring of Sword)
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            // Arrange
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            // Act

            // Assert
            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveNotEmptyDefaultWeapons()
        {
            // Arrange

            // Act

            // Assert
            // loop through the list (weapons) and check if matches the predicate (each item must pass the assert)
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            // Arrange

            // Act

            // Assert
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            // Arrange

            // Act

            // Assert
            // object must implement INotifyPropertyChanged interface
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        // data-driven test
        // this attribute tell xUnit that this method should be executed multiple times
        // and for each execution, this method needs to be provided with some test data
        // [InlineData] is of the ways to enter test data, first parameter for damage, second for expectedHealth
        // [InlineData] cannot share the test data across test methods or test classes
        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        // [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        // [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        // [HealthDamageData] // Custom test data attribute
        public void TakeDamage(int damage, int expectedHealth)
        {
            // Arrange

            // Act
            _sut.TakeDamage(damage);

            // Assert
            Assert.Equal(expectedHealth, _sut.Health);
        }

        public void Dispose()
        {
            // This method will executed after each test method runs
            // because each test method create a class instance
            
            // Clean up code like
            //_sut.Dispose();
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
