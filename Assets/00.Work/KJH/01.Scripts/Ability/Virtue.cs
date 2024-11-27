using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Virtue
{
    /// <summary>덕목의 포인트</summary>
    protected int Points { get; private set; } = 0;
    
    /// <summary>덕목의 스킬해금을 결정하는 불값</summary>
    public bool FirstStackPoint { get; set; } = false;
    public bool SecondStackPoint { get; set; } = false;
    
    
    public float FirstStatsPoint { get; set; } = 0f;
    public float SecondStatsPoint { get; set; } = 0f;
    
    /// <summary>덕목의 스킬 이름</summary>
    public string FirstStatsPointName { get; set; }
    public string SecondStatsPointName { get; set; }
    
    /// <summary>덕목의 스킬에 사용되는 스택(스택이 필요한 경우에만 사용)</summary>
    public float Stack { get; set; } = 0f;

     /// <summary>
    /// 포인트가 올라가면 플레이어의 스탯을 증가 시키는 메서드
    /// </summary>
    /// <param name="stats">플레이어 스탯을 가져와 증가시키는 함수를 실행</param>
    protected abstract void ApplyStatBonuses(PlayerAbility stats);
     
     /// <summary>
     /// 포인트가 특정구간을 넘을시 덕목의 스킬을 해금시키는 함수
     /// </summary>
    protected abstract void ApplySpecialEffects();
    
     /// <summary>
     /// 덕목의 첫번째 스킬을 조건에 따라 실행시키는 함수
     /// </summary>
     /// <param name="stats">플레이어의 스탯을 증가 시키기 위한 함수</param>
    protected abstract void ApplyFirstStatsPoint(PlayerAbility stats);
     
     /// <summary>
     /// 덕목의 첫번째 스킬을 조건에 따라 실행시키는 함수
     /// </summary>
     /// <param name="stats">플레이어의 스탯을 증가 시키기 위한 함수</param>
    protected abstract void ApplySecondStatsPoint(PlayerAbility stats);
    
    /// <summary>
    /// 해당 덕목의 포인트를 올리고 스탯을 올림 + 쌓인 포인트에 따라 해당 덕목의 특수능력이 해금됨
    /// </summary>
    /// <param name="stats">PlayerAbility의 능력치를 조정하기 위해 가져옴</param>
    public void AddPoint(PlayerAbility stats)
    {
        Points++;
        ApplyStatBonuses(stats);
        
        if (Points == 10 || Points == 20)
        {
            ApplySpecialEffects();
        }
    }

    /// <summary>덕목의 특수능력들의 이름을 정의 하는 함수</summary>
    public abstract void ApplyName();

}
