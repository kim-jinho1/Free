using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentration : Virtue
{
    
    /// <summary>
    /// 덕목의 특수능력 이름
    /// </summary>
    protected override void ApplyName()
    {
        FirstStatsPointName = "선수필승";
        SecondStatsPointName = "F=ma";
    }
    
    /// <summary>
    /// 포인트가 올라가면 플레이어의 스탯을 증가 시키는 메서드
    /// </summary>
    /// <param name="stats">플레이어 스탯을 가져와 증가시키는 함수를 실행</param>
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseSpeed(1);
        stats.IncreaseDodge(2f);
    }
    
    /// <summary>
    /// 특정 구간을 포인트를 넘을시 해금되는 추가 스킬
    /// </summary>
    protected override void ApplySpecialEffects()
    {
        if (Points == 10)
        {
            FirstStackPoint = true;
        }
        else if (Points == 20)
        {
            SecondStackPoint = true;
        }
    }

    protected override void ApplyFirstStatsPoint(PlayerAbility stats)
    {
       stats.IncreaseCritical(20);
    }

    protected override void ApplySecondStatsPoint(PlayerAbility stats)
    {
        stats.IncreaseAttack(stats.Speed / 2);
    }
}