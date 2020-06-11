using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        private readonly PlayerCharacter _sut;

        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperincedWehenNew()
        {
            // Arrange
            //PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            _sut.FirstName = "Hidayat";
            _sut.LastName = "Arghandabi";

            // Assert
            Assert.Equal("Hidayat Arghandabi", _sut.FullName);
        }

        [Fact]
        public void FullNameStartingWith()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Hidayat";
            sut.LastName = "Arghandabi";

            // Assert
            Assert.StartsWith("Hidayat", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_Ignore_CaseAssert()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "HIDAYAT";
            sut.LastName = "ARGHANDABI";

            // Assert
            Assert.Equal("Hidayat Arghandabi", sut.FullName, ignoreCase: true);
            // case ignore doesnot pay attention
        }

        [Fact]
        public void CalculateFullName_SubStringContains()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Hidayat";
            sut.LastName = "Arghandabi";

            // Assert
            Assert.Contains("at Ar", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Hidayat";
            sut.LastName = "Arghandabi";

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.Sleep(); // Expect increase between 1 to 100 inclusive

            // Assert
            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            // OR
            Assert.InRange<int>(sut.Health, 101, 200);
        }

        [Fact]
        public void NickNameByDefaultIsNull()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.Null(sut.Nickname);

        }

        [Fact]
        public void HaveALongBow()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapon()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            // Assert
            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapon()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void TakeMediumDamage()
        {
            _sut.TakeDamage(50);
            Assert.Equal(50, _sut.Health);
        }

        [Fact]
        public void HaveMinimumHealth()
        {
            _sut.TakeDamage(101);
            Assert.Equal(1, _sut.Health);
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }
    }
}
