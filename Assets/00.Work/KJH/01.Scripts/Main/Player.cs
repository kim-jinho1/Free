using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigid { get; private set; }

    public PlayerStateMachine StateMachine { get; private set; }

    public Vector2 MoveInput { get; private set; }
    private float _yVelocity;

    private bool _dirRight = true;
    private int _dir = 1;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigid = GetComponent<Rigidbody2D>();

        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(PlayerStateEnum.Idle, new PlayerIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(PlayerStateEnum.Move, new PlayerMoveState(this, StateMachine, "Move"));
    }

    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        StateMachine.currentState.Update();

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                CheckRoom(hit.collider);
            }
        }
        
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), _yVelocity);
    }

    private void CheckRoom(Collider2D hitCollider)
    {
        if (hitCollider.GetComponent<VerticalRoom>() is not null)
        {
            
        }
        else if (hitCollider.GetComponent<HorizontalRoom>() is not null)
        {
            
        }
    }

    public void FiIpController()
    {
        if (Rigid.velocity.x > 0 && _dirRight == false) 
        {
            FiIp();
        }
        else if (Rigid.velocity.x < 0 && _dirRight == true) 
        {
            FiIp();
        }
    }

    private void FiIp()
    {
        _dirRight = !_dirRight;
        _dir *= -1;
        transform.Rotate(0, 180, 0);
    }
}
