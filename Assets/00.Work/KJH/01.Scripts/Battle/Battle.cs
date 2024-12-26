using System;
using UnityEngine;
using DG.Tweening;

public class Battle : MonoBehaviour
{
    [SerializeField] private GameObject _battlePanel;

    public Action<Enemy> OnPlayerAttack;
    public Action<Enemy> OnEnemyAttack;

    public GameObject target { get; set; }

    public Player _player;

    public bool Attack { get; set; }

    public Animator Animator { get; private set; }

    public BattleStateMachine StateMachine { get;  set; }

    public int turn { get; set; }


    private void Awake()
    {
        turn = 0;

        StateMachine = new BattleStateMachine();
        StateMachine.AddState(BattleStateEnum.StartState, new BattleStartState(this, StateMachine, "PlayerIdle"));
        StateMachine.AddState(BattleStateEnum.MiddleState, new BattleMiddleState(this, StateMachine, "PlayerIdle"));
        StateMachine.AddState(BattleStateEnum.EndState, new BattleEndState(this, StateMachine, "PlayerIdle"));
        StateMachine.AddState(BattleStateEnum.NotState, new BattleNotState(this, StateMachine, "PlayerIdle"));
    }

    private void Start()
    {
        StateMachine.Initialize(BattleStateEnum.NotState);
    }

    private void OnEnable()
    {
        OnPlayerAttack += PlayerAttack;
        OnEnemyAttack += EnemyAttack;
        RightRoom.OnEnemy += SetTarGet;
        LeftRoom.OnEnemy += SetTarGet;
        CenterRoom.OnEnemy += SetTarGet;
    }

    private void OnDisable()
    {
        OnPlayerAttack -= PlayerAttack;
        OnEnemyAttack -= EnemyAttack;
        RightRoom.OnEnemy -= SetTarGet;
        LeftRoom.OnEnemy -= SetTarGet;
        CenterRoom.OnEnemy -= SetTarGet;
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

    public void PlayerAttack(Enemy en)
    {
        _battlePanel.SetActive(true);
        _battlePanel.transform.DOMove(new Vector3(960, 540), 1f).SetEase(Ease.OutExpo);
        turn++;
        en.myTurn = true;

    }

    public void EnemyAttack(Enemy en)
    {
        turn++;
        en.enemyHealth.CurrentHp -= _player.AbilityData.attack;
    }

    private void SetTarGet(GameObject en)
    {
        target = en;
    }
}
