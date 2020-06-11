using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {

        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        [Trait("Category", "Boos")]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Enemy");
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
