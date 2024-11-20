using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Courage : Virtue
{
    //용기
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseAttack(1);
        stats.IncreaseCritical(0.02f);
        stats.IncreaseEscape(0.01f);
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
        if (Stack <= 5) 
        {
            stats.IncreaseAttack(1);
            Stack++;
        }
    }

    protected override void ApplyTwentiesStats(PlayerAbility stats)
    {
        float a = CalculatePercentage(stats.MaxHealth, 2);
        stats.IncreaseHp(a);
        Debug.Log($"{stats.MaxHealth}의 {2}%는 {a}입니다.");
    }
    
    float CalculatePercentage(float number, float percentage)
    {
        return (number * percentage) / 100f;
    }
}