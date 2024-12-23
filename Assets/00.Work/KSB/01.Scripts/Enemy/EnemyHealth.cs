using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy _enemy;
    private int _fullHp;
    public bool isDeath = false;
    public int _currentHp;
    private bool prePassiveTrigger = false;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        _fullHp = _enemy.enemyData.Hp;
        CurrentHp = _enemy.enemyData.Hp;
        Debug.Log(CurrentHp);

    }

    private void Update()
    {
        if(isDeath)
        {
            _currentHp = 0;
        }
        if (CurrentHp <= _fullHp / 2&& !prePassiveTrigger)
        {
            Passive_Skill();
        }
    }
    private int CurrentHp
    {
        get
        {
            return _currentHp;
        }
        set
        {
            if (value > _fullHp)
            {
                _currentHp = 0;
            }
            else
            {
                _currentHp = value;
            }
        }
    }
    public int GetCurrentHp()
    {
        return CurrentHp;
    }
    public void DamageApply(int Damage,int WeaponDamage)//ÀÌ°É·Î Ã¼·Â ±ðÀ¸¼Å
    {

        CurrentHp -= Damage+WeaponDamage;

        if (CurrentHp <= 0)
        {
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Death));
        }
        else
        { 
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Hit));

        }
       
    }


    private void Passive_Skill()
    {
        prePassiveTrigger = true;
        _enemy.enemyData.ActivatePassiveSkill();

      
    }
}
