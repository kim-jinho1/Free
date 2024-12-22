using System;
using UnityEngine;
using DG.Tweening;

public class Battle : MonoBehaviour
{
    [SerializeField] private GameObject _battlePanel;

    public Action OnPlayerAttack;
    public Action OnEnemyAttack;

    public GameObject target { get; set; }

    public Player _player;

    public bool Attack { get; set; }

    public Animator Animator { get; private set; }

    public BattleStateMachine StateMachine { get; private set; }

    public int turn { get; set; }


    private void Awake()
    {
        turn = 0;

        OnPlayerAttack += PlayerAttack;
        OnEnemyAttack += EnemyAttack;

        StateMachine.AddState(BattleStateEnum.StartState, new BattleStartState(this, StateMachine, "Idle"));
        StateMachine.AddState(BattleStateEnum.MiddleState, new BattleMiddleState(this, StateMachine, "Attack"));
        StateMachine.AddState(BattleStateEnum.EndState, new BattleEndState(this, StateMachine, "HorizontalMove"));
        StateMachine.AddState(BattleStateEnum.NotState, new BattleNotState(this, StateMachine, "HorizontalMove"));
    }

    private void Update()
    {
        StateMachine.currentState.Update();
        if (turn % 2 == 0)
        {
            Attack = true;
        }
        else if (turn % 2 == 0)
        {
            Attack = false;
        }
    }

    public void PlayerAttack()
    {
        _battlePanel.SetActive(true);
        _battlePanel.transform.DOMove(new Vector3(960, 540), 1f).SetEase(Ease.OutExpo);
        turn++;
        //적의 체력을 깍는다
    }

    public void EnemyAttack()
    {
        turn++;
        //나의 체력을 깍는다
    }

}
