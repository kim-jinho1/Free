using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Enemy_State currentState;
    public AnimationCompo_SB animationCompo;
    public StateCompo stateCompo;
    public EnemyData enemyData;
    public EnemyHealth enemyHealth;
    public bool myTurn = false;
    private void Awake()
    {
        
        stateCompo = GetComponentInChildren<StateCompo>();
        animationCompo = GetComponentInChildren<AnimationCompo_SB>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyData = GetComponentInChildren<EnemyData>();

    }
    void Start()
    {
        TransitionState(stateCompo.GetState(StateType.Idle));
        print(enemyHealth.GetCurrentHp());
    }
    void Update()
    {
        currentState.StateUpdate();
        if (Input.GetMouseButtonDown(0))
        {
           HitTest();
        }
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }

    public void TransitionState(Enemy_State InputState)
    {

        if (InputState == null)
        {
            Debug.LogError("¾ø¾û");
            return;
        }

        if (currentState == InputState)
            return;
        if (currentState != null)
            currentState.Exit();

        currentState = InputState;

        currentState.InitializeState(this);
        currentState.Enter();


    }

    public AnimationType ChooseAttack(int mainAttackRate)
    {
        int RanNum = Random.Range(0, 100);
        if (RanNum >= mainAttackRate)
        {
            return AnimationType.Attack2;
        }
        else
        {
            return AnimationType.Attack;
        }

    }

    public void HitTest()
    {
        print("Èý");
        enemyHealth.HpChange(10);
        print(enemyHealth.GetCurrentHp());
    }
}
