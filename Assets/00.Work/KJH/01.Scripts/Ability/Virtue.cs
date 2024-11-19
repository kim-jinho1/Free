using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Virtue
{
    protected int Points { get; private set; } = 0;
    public bool TenStack { get; set; } = false;
    public bool TwentiesStack { get; set; } = false;
    public float TenStats { get; set; } = 0f;
    public float TwentiesStats { get; set; } = 0f;
    public float Stack { get; set; } = 0f;

    protected abstract void ApplyStatBonuses(PlayerAbility stats);
    protected abstract void ApplySpecialEffects(PlayerAbility stats);
    
    protected abstract void ApplyTenStats(PlayerAbility stats);
    protected abstract void ApplyTwentiesStats(PlayerAbility stats);
    
    public void AddPoint(PlayerAbility stats)
    {
        Points++;
        ApplyStatBonuses(stats);
        
        if (Points == 10 || Points == 20)
        {
            ApplySpecialEffects(stats);
        }
    }
    
}
