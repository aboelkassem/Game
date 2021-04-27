using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        [Theory]
        // [MemberData] used to share the same test data across multiple methods, which read from this class
        //[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        [HealthDamageData] // Custom test data attribute
        public void TakeDamage(int damage, int expectedHealth)
        {
            // Arrange
            NonPlayerCharacter sut = new NonPlayerCharacter();

            // Act
            sut.TakeDamage(damage);

            // Assert
            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
