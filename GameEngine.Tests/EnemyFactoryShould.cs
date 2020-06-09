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
            // Assert
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie");

            // Assert
            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            // Assert
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            // Assert
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
            // Assert
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            Assert.IsAssignableFrom<Enemy>(enemy);
        }
    }
}
