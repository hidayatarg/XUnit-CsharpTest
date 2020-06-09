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
    }
}
