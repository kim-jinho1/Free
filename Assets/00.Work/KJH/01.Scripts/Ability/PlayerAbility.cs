using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private Player _player;

    #region AbilitySetting
    //공격력
    public float AttackPower
    {
        get => _player.AbilityData.attackPower;
        set => _player.AbilityData.attackPower = value;
    }
    //체력
    public float Hp
    {
        get => _player.AbilityData.hp;
        set => _player.AbilityData.hp = value;
    }
    //속도
    public float Speed
    {
        get => _player.AbilityData.speed;
        set => _player.AbilityData.speed = value;
    }
    //회피율
    public float EvasionRate
    {
        get => _player.AbilityData.dodge;
        set => _player.AbilityData.dodge = value;
    }
    //명중률
    public float Accuracy
    {
        get => _player.AbilityData.accuracy;
        set => _player.AbilityData.accuracy = value;
    }
    //도주율
    public float EscapeRate
    {
        get => _player.AbilityData.escape;
        set => _player.AbilityData.escape = value;
    }
    //치명타율
    public float CriticalStrikeRate
    {
        get => _player.AbilityData.critical;
        set => _player.AbilityData.critical = value;
    }
    //치명타 피해
    public float CriticalDamage{
        get => _player.AbilityData.criticalAttack;
        set => _player.AbilityData.criticalAttack = value;
    }
    
    //최대 체력
    public int MaxHealth { get; private set; } = 100;
    
    #endregion

    public void IncreaseAttackPower(float amount) => AttackPower += amount;
    public void IncreaseHp(float amount) => Hp += amount;
    public void IncreaseSpeed(float amount) => Speed += amount;
    public void IncreaseEvasionRate(float amount) => EvasionRate += amount;
    public void IncreaseAccuracy(float amount) => Accuracy += amount;
    public void IncreaseEscapeRate(float amount) => EscapeRate += amount;
    public void IncreaseCriticalStrikeRate(float amount) => CriticalStrikeRate += amount;
    
    public void IncreaseCriticalDamage(float amount) => CriticalStrikeRate += amount;
    
    public void IncreaseMaxHealth(int amount) => CriticalDamage += amount;
}
