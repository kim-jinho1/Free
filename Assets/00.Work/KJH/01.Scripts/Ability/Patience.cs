using UnityEngine;

public class Patience : Virtue
{
    /// <summary>
    /// 덕목의 특수능력 이름
    /// </summary>
    public override void ApplyName()
    {
        FirstStatsPointName = "탄탄한 근육";
        SecondStatsPointName = "벌크업";
    }
    
    /// <summary>
    /// 포인트가 올라가면 플레이어의 스탯을 증가 시키는 메서드
    /// </summary>
    /// <param name="stats">플레이어 스탯을 가져와 증가시키는 함수를 실행</param>
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        //stats.IncreaseHp(10);
    }
    
    /// <summary>
    /// 특정 구간을 포인트를 넘을시 해금되는 추가 스킬
    /// </summary>
    protected override void ApplySpecialEffects()
    {
        if (Points == 10)
        {
            FirstStackPoint = true;
            //CalculatePercentage()
        }
        else if (Points == 20)
        {
            SecondStackPoint = true;
        }
    }

    protected override void ApplyFirstStatsPoint(PlayerAbility stats)
    {
        if (FirstStackPoint)
        {
            stats.DamageDown = 20f;
        }
    }

    protected override void ApplySecondStatsPoint(PlayerAbility stats)
    {
        if (SecondStackPoint)
        {
            stats.Dodge = 10f;
            stats.DamageDown = 40f;
        }
    }
    
    float CalculatePercentage(float number, float percentage)
    {
        return (number * percentage) / 100f;
    }
}