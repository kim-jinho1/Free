using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentration : Virtue
{
    //집중
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseSpeed(1);
        stats.IncreaseDodge(2f);
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
       stats.IncreaseCritical(20);
    }

    protected override void ApplyTwentiesStats(PlayerAbility stats)
    {
       stats.IncreaseAttack(stats.Speed);
    }
}
