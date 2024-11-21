using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisdom : Virtue
{
    /// <summary>
    /// 덕목의 특수능력 이름
    /// </summary>
    protected override void ApplyName()
    {
        FirstStatsPointName = "게릴라전";
        SecondStatsPointName = "전투 분석";
    }
    
    private bool istrue = false;

    private int turn = 0;
    /// <summary>
    /// 포인트가 올라가면 플레이어의 스탯을 증가 시키는 메서드
    /// </summary>
    /// <param name="stats">플레이어 스탯을 가져와 증가시키는 함수를 실행</param>
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseAccuracy(2f);
        stats.IncreaseDodge(2f);
    }

    /// <summary>
    /// 특정 구간을 포인트를 넘을시 해금되는 덕목의 특수 능력
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
        
    }

    protected override void ApplySecondStatsPoint(PlayerAbility stats)
    {
        if (turn>=4)
        {
            stats.IncreaseAttack(10);
            stats.IncreaseSpeed(5);
            stats.IncreaseCritical(5);
        }
    }
}