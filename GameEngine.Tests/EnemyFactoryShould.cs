using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
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

        [Fact]
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
    }
}
