using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperincedWehenNew()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act

            // Assert
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Hidayat";
            sut.LastName = "Arghandabi";

            // Assert
            Assert.Equal("Hidayat Arghandabi", sut.FullName);
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
    }
}
