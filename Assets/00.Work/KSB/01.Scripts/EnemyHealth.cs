using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy _enemy;
    private int _fullHp;
    public bool isDeath = false;
    public int _currentHp;

    private int CurrentHp
    {
        get
        {
            return _currentHp;
        }
        set
        {
            if(value >_fullHp)
            {
                _currentHp = 0;
            }
            else
            {
                _currentHp = value;
            }
        }
    }

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

    public int GetCurrentHp()
    {
        return CurrentHp;
    }
    public void HpChange(int Damage)
    {

        CurrentHp -= Damage;

        if (CurrentHp <= 0)
        {
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Death));
        }
        else
        { 
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Hit));

        }
       
    }
  
}
