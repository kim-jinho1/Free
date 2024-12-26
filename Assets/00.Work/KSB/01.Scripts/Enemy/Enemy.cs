using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy_State currentState;
    public AnimationCompo_SB animationCompo;
    public StateCompo stateCompo;
    public EnemyData enemyData;
    public EnemyHealth enemyHealth;
    public bool myTurn = false;//���� (�̰� true �Ǹ� ���� ���ķ� idle�� ���ƿ��� ���)
                               //�İ� EnemyHealth���� damageApply ���� 

    private void Awake()
    {
        stateCompo = GetComponentInChildren<StateCompo>();
        animationCompo = GetComponentInChildren<AnimationCompo_SB>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyData = GetComponentInChildren<EnemyData>();
    }

    void Start()
    {
        print(enemyData.Hp_Passive_Rng+" sobin");
        TransitionState(stateCompo.GetState(StateType.Idle));
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
            Debug.LogError("����");
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

    public AnimationType ChooseAttack(int Skill2_Rate, int Skill1_Rate)
    {
        int RanNum = Random.Range(0, 100);
        if (RanNum < Skill2_Rate)
        {
            return AnimationType.Attack2;
        }
        else if (RanNum < Skill1_Rate)
        {
            return AnimationType.Attack;
        }
        else
        return AnimationType.Attack;
    }
}