using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy _enemy;
    public bool isDeath = false;
    private int _currentHp;
    public event Action OnDeath;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        _currentHp = _enemy.enemyData.Hp;
    }

    public void HpChange(int Damage)
    {
        if(Damage < 0)
        {
            Hp -= Damage;
            _enemy.TransitionState(_enemy.stateCompo.GetState(StateType.Hit));
          
        }
        else
        {
            _enemy.CanAttack = true;
        }
    }
    public int Hp
    {
        get
        {
            return _currentHp;
        }
        set
        {
            if (value  > 0)
            {
                _currentHp = value;
            }
            else
            {
                _currentHp = 0;
            }
        }
    }
}
