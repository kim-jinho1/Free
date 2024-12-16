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
        TransitionState(stateCompo.GetState(StateType.Idle));//시작할때 idle로 시작하거든 거기서 이 스크립트에 있는
                                                           //myTurn을 true로 만들어 주면 Attack으로 넘어감
        print(enemyHealth.GetCurrentHp());
    }
    void Update()
    {
        currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }

    public void TransitionState(Enemy_State InputState)
    {

        if (InputState == null)
        {
            Debug.LogError("없엉");
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

    public AnimationType ChooseAttack(int mainAttackRate)//Attack이 2개인 보스들을 위한
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
}
