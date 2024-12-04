using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _pos;
    [SerializeField] private AbilityData _abilityData;
    [SerializeField] public GameObject _panel;
    
    public Action<Transform> OnMoveVertical;
    public Action<Transform> OnMoveHorizontal;

    public Action<int> OnAttack;
    public Action<int> OnHit;

    public AbilityData AbilityData => _abilityData;
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigid { get; private set; }
    
    public bool IsCenter {get; set;}
    public Transform CenterPosition { get; set; }
    public int CurrentFloor { get; set; }

    private PlayerStateMachine StateMachine { get; set; }

    private bool _dirRight = true;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(PlayerStateEnum.Idle, new PlayerIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(PlayerStateEnum.Attack, new PlayerAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(PlayerStateEnum.HorizontalMove, new PlayerHorizontalMoveState(this, StateMachine, "HorizontalMove"));
        StateMachine.AddState(PlayerStateEnum.VerticalMove, new PlayerVerticalMoveState(this, StateMachine, "VerticalMove"));
        StateMachine.AddState(PlayerStateEnum.UI, new PlayerUIState(this, StateMachine, "VerticalMove"));
        
    }
    
    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle);
        Reset();
    }

    private void Reset()
    {
        CurrentFloor = 1;
        CenterPosition = _pos;
        IsCenter = true;
    }

    private void Update()
    {
        StateMachine.currentState.PlayerUpdate();
    }

    public void FiIpController()
    {
        if (Rigid.velocity.x > 0 && _dirRight == false) 
        {
            FiIp();
        }
        else if (Rigid.velocity.x < 0 && _dirRight) 
        {
            FiIp();
        }
    }

    private void FiIp()
    {
        _dirRight = !_dirRight;
        transform.Rotate(0, 180, 0);
    }
    
    
}
