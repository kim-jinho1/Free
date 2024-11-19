using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : Virtue
{
    //인내
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseHp(10);
    }

    protected override void ApplySpecialEffects(PlayerAbility stats)
    {
        if (Points == 10)
        {
            TenStack = true;
            //CalculatePercentage()
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
       
    }
    
    float CalculatePercentage(float number, float percentage)
    {
        return (number * percentage) / 100f;
    }
}
