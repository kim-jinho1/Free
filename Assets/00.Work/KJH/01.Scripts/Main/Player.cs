using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _pos;
    [SerializeField] private AbilityData _abilityData;


    public Action<Transform> OnMoveVertical;
    public Action<Transform> OnMoveHorizontal;

    public Action<int> OnAttack;
    public Action<int> OnHit;

    public AbilityData AbilityData => _abilityData;
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigid { get; private set; }

    public bool IsCenter { get; set; }

    /// <summary>0이면 센터 1이면 오른쪽 2면 왼쪽</summary>
    public static int CurrentRoom { get; set; }
    public Transform CenterPosition { get; set; }
    public int CurrentFloor { get; set; }

    public PlayerStateMachine StateMachine { get; set; }

    public Collider2D Collider { get; set; }

    private bool _dirRight = true;

    private void Awake()
    {

        Animator = GetComponentInChildren<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
        StateMachine = new PlayerStateMachine();

        StateMachine.AddState(PlayerStateEnum.Idle, new PlayerIdleState(this, StateMachine, "PlayerIdle"));
        StateMachine.AddState(PlayerStateEnum.Attack, new PlayerAttackState(this, StateMachine, AttackAnim()));
        StateMachine.AddState(PlayerStateEnum.HorizontalMove, new PlayerHorizontalMoveState(this, StateMachine, "PlayerRun"));
        StateMachine.AddState(PlayerStateEnum.UI, new PlayerUIState(this, StateMachine, "PlayerIdle"));

    }

    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle);
        PlayerReset();
    }

    private void PlayerReset()
    {
        CurrentRoom = 0;
        CurrentFloor = 1;
        CenterPosition = _pos;
        IsCenter = true;
    }

    private void Update()
    {
        FiIpController();
        StateMachine.currentState.Update();

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
                ClickRoom(hit.collider);
        }
    }

    public void ClickRoom(Collider2D hitCollider)
    {
        Collider = hitCollider;
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

    private string AttackAnim()
    {
        int rnad = UnityEngine.Random.Range(0, 2);
        switch (rnad)
        {
            case 0:
                return "PlayerAttack2";
                break;
            case 1:
                return "PlayerAttack1";
                break;
            default:
                return "PlayerAttack1";
                break;
        }
    }
}