using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoSingleton<PlayerAbility>
{
    [SerializeField] private Player _player;

    private float _attack = 0;
    private float _speed = 0;
    private float _dodge = 0;
    private float _accuracy = 0;
    private float _escape = 0;
    private float _critical = 0;
    private float _criticalAtack = 0;
    private float _maxHp = 0;
    private float _currentHp = 0;
    private float _currentHungry = 0;
    private float _maxHungry = 0;
    private float _damageedown = 0;

    private void Awake()
    {
        _attack = _player.AbilityData.attack;
        _speed = _player.AbilityData.speed;
        _dodge = _player.AbilityData.dodge;
        _accuracy = _player.AbilityData.accuracy;
        _escape = _player.AbilityData.escape;
        _critical = _player.AbilityData.critical;
        _criticalAtack = _player.AbilityData.criticalAttack;
        _maxHp = _player.AbilityData.maxHp;
        _currentHp = _player.AbilityData.currentHp;
        _currentHungry = _player.AbilityData.currentHungry;
        _maxHungry = _player.AbilityData.maxHungry;
    }

    #region 능력치 세팅
    //공격력
    public float Attack
    {
        get => _attack;
        set => _attack = value;
    }
    //속도
    public float Speed
    {
        get => _speed;
        set => _speed = value;
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
    public float CriticalAttack
    {
        get => _player.AbilityData.criticalAttack;
        set => _player.AbilityData.criticalAttack = value;
    }
    //최대 체력
    public float MaxHealth {  
        get => _player.AbilityData.maxHp;
        set => _player.AbilityData.maxHp = value; 
    }
    //현재체력
    public float CurrentHp
    {
        get => _player.AbilityData.maxHp;
        set => _player.AbilityData.maxHp = value; 
    }
    //현재배고픔
    public float CurrentHungry
    {
        get => _player.AbilityData.maxHungry;
        set => _player.AbilityData.maxHungry = value; 
    }
    //최대배고픔수치
    public float MaxHungry
    {
        get => _player.AbilityData.maxHungry;
        set => _player.AbilityData.maxHungry = value; 
    }
    //받는 피해 감소
    public float DamageDown
    {
        get => _player.AbilityData.damageDown;
        set => _player.AbilityData.damageDown = value; 
    }
    
    #endregion

    #region 능력치 증가 합수
    
    public void IncreaseAttack(float amount) => Attack += amount;
    public void IncreaseSpeed(float amount) => Speed += amount;
    public void IncreaseDodge(float amount) => Dodge += amount;
    public void IncreaseAccuracy(float amount) => Accuracy += amount;
    public void IncreaseEscape(float amount) => Escape += amount;
    public void IncreaseCritical(float amount) => Critical += amount;
    public void IncreaseCriticalAttack(float amount) => CriticalAttack += amount;
    public void IncreaseCurrentHp(float amount) => CurrentHp += amount;
    public void IncreaseMaxHealth(float amount) => MaxHealth += amount;
    public void IncreaseCurrentHungry(float amount) => CurrentHungry += amount;
    public void IncreaseMaxHungry(float amount) => MaxHungry += amount;
    public void IncreaseDamageDown(float amount) => DamageDown += amount;

    #endregion
}
