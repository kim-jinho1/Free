using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private Player _player;

    #region AbilitySetting
    //공격력
    public float Attack
    {
        get => _player.AbilityData.attack;
        set => _player.AbilityData.attack = value;
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
    public float Dodge
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
    public float Escape
    {
        get => _player.AbilityData.escape;
        set => _player.AbilityData.escape = value;
    }
    //치명타율
    public float Critical
    {
        get => _player.AbilityData.critical;
        set => _player.AbilityData.critical = value;
    }
    //치명타 피해
    public float CriticalAttack{
        get => _player.AbilityData.criticalAttack;
        set => _player.AbilityData.criticalAttack = value;
    }
    
    //최대 체력
    public int MaxHealth { get; private set; } = 100;
    
    #endregion

    public void IncreaseAttack(float amount) => Attack += amount;
    public void IncreaseHp(float amount) => Hp += amount;
    public void IncreaseSpeed(float amount) => Speed += amount;
    public void IncreaseDodge(float amount) => Dodge += amount;
    public void IncreaseAccuracy(float amount) => Accuracy += amount;
    public void IncreaseEscape(float amount) => Escape += amount;
    public void IncreaseCritical(float amount) => Critical += amount;
    
    public void IncreaseCriticalAttack(float amount) => CriticalAttack += amount;
    
    public void IncreaseMaxHealth(int amount) => MaxHealth += amount;
}
