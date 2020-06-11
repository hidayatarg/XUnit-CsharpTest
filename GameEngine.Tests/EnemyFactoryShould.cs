using System;
using System.Collections.Generic;
using System.Text;
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
        public void CreateBossEnemy()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact(Skip = "Currently this test is skipped no need to run")]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);
            // Extra Assert
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

        // Enemy factory create two types of enemy 
        [Fact]
        public void CreateSeparateInstances()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            // Assert 
            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act

            // Assert 
            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            // Assert 
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
