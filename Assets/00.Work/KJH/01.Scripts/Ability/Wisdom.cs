using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisdom : Virtue
{
    //현명
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseAccuracy(0.02f);
        stats.IncreaseEvasionRate(0.02f);
    }

    protected override void ApplySpecialEffects(PlayerAbility stats)
    {
        if (Points == 10)
        {
            TenStack = true;
        }
        else if (Points == 20)
        {
            TwentiesStack = true;
        }
    }

    protected override void ApplyTenStats(PlayerAbility stats)
    {
        
    }

    protected override void ApplyTwentiesStats(PlayerAbility stats)
    {
        stats.IncreaseAttackPower(10);
        stats.IncreaseSpeed(5);
        stats.IncreaseCriticalStrikeRate(5);
    }
}
