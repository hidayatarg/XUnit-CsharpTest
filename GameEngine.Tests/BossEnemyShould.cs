﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.SpecialPowerUses, 3);
        }
    }
}