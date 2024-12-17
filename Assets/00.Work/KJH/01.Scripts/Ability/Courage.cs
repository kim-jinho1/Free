using UnityEngine;

public class Courage : Virtue
{
    /// <summary>
    /// 덕목의 특수능력 이름
    /// </summary>
    public override void ApplyName()
    {
        FirstStatsPointName = "전투 경험";
        SecondStatsPointName = "블러드 웨폰";
    }

    private bool critical = false;
    /// <summary>
    /// 포인트가 올라가면 플레이어의 스탯을 증가 시키는 메서드
    /// </summary>
    /// <param name="stats">플레이어 스탯을 가져와 증가시키는 함수를 실행</param>
    protected override void ApplyStatBonuses(PlayerAbility stats)
    {
        stats.IncreaseAttack(1);
        stats.IncreaseCritical(2f);
        stats.IncreaseEscape(1f);
    }

    /// <summary>
    /// 특정 구간을 포인트를 넘을시 해금되는 추가 스킬
    /// </summary>
    protected override void ApplySpecialEffects()
    {
        Debug.Log(1);
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
        if (FirstStackPoint && Stack <= 5)
        {
            stats.IncreaseAttack(1);
            Stack++;
        }
    }

    protected override void ApplySecondStatsPoint(PlayerAbility stats)
    {
        if (SecondStackPoint && critical)
        {
            float a = CalculatePercentage(stats.MaxHealth, 2);
            stats.IncreaseHp(a);
            Debug.Log($"{stats.MaxHealth}의 {2}%는 {a}입니다.");
            critical = false;
        }
    }

    float CalculatePercentage(float number, float percentage)
    {
        return (number * percentage) / 100f;
    }
}