using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private EnemySO enemySO;

    [Header("About normalSetting")]
    private int _hp;
    private int _fullHp;
    private int _attackDamage;
    private float _attackSpeed;
    private int _attackSucRate;


    [Header("About Damage Rate")]
    private int _headRNG;
    private int _bodyRNG;
    private int _armRNG;

    [Header("About Damage Of Part")]
    private float headDamage;
    private float bodyDamage;
    private float armDamage;

    [Header("Passive_Skill_Rng")]
    private int _attack_Passive_Rng;
    private int _speed_Passive_Rng;

    [Header("For Boss")]
    int _skill2_Rng;
    int _skill1_Rng;
    private int Attack2Damage;

    [Header("Sprite")]
    public Sprite[] _hitPointSprite;

    private void Awake()
    {
        _fullHp = enemySO.hp;
        Hp = enemySO.hp;

        Attack_Passive_Rng = enemySO._attack_Passive_Rng;
        Speed_Passive_Rng = enemySO._speed_Passive_Rng;

        AttackDamage = enemySO.skill1_AttackDamage;
        Attack2Damage = enemySO.skill2_AttackDamage;
        AttackSpeed = enemySO.attackSpeed;

        AttackSucRate = enemySO.attackSucRate;
        _skill1_Rng = enemySO.skill1_AttackRate;
        _skill2_Rng = enemySO.skill2_AttackRate;

        HeadRNG = enemySO.HeadRNG;
        BodyRNG = enemySO.BodyRNG;
        ArmRNG = enemySO.ArmRNG;

        headDamage = enemySO.HeadDamage;
        bodyDamage = enemySO.BodyDamage;
        armDamage = enemySO.ArmDamage;

        // HitPoint Sprite ������ ����
        _hitPointSprite = enemySO.HitPoint;
    }

    public int Skill2_Rng
    {
        get { return _skill2_Rng; }
        set
        {
            if (value < 0)
            {
                _skill2_Rng = 0;
            }
            else if (value > 100)
            {
                _skill2_Rng = 100;
            }
            else
                _skill2_Rng = value;

        }
    }

    public int Skill1_Rng
    {
        get { return _skill1_Rng; }
        set
        {
            if (value < 0)
            {
                _skill1_Rng = 0;
            }
            else if (value > 100)
            {
                _skill1_Rng = 100;
            }
            else
                _skill1_Rng = value;

        }
    }
    public int Hp
    {
        get { return _hp; }
        set
        {
            _hp = Mathf.Clamp(value, 0, _fullHp);
            if (_hp <= 0)
            {
                OnDeath();
            }
        }
    }

    public int AttackDamage
    {
        get { return _attackDamage; }
        set { _attackDamage = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    public int AttackSucRate
    {
        get { return _attackSucRate; }
        set { _attackSucRate = value; }
    }

    public int Attack_Passive_Rng
    {
        get { return _attack_Passive_Rng; }
        set { _attack_Passive_Rng = value; }
    }

    public int Speed_Passive_Rng
    {
        get { return _speed_Passive_Rng; }
        set { _speed_Passive_Rng = value; }
    }

    public int HeadRNG
    {
        get { return _headRNG; }
        set { _headRNG = value; }
    }

    public int BodyRNG
    {
        get { return _bodyRNG; }
        set { _bodyRNG = value; }
    }

    public int ArmRNG
    {
        get { return _armRNG; }
        set { _armRNG = value; }
    }

    public float HeadDamage
    {
        get { return headDamage; }
        set { headDamage = value; }
    }

    public float BodyDamage
    {
        get { return bodyDamage; }
        set { bodyDamage = value; }
    }

    public float ArmDamage
    {
        get { return armDamage; }
        set { armDamage = value; }
    }
    public int GetDamage(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.Attack2:
                return AttackDamage; // ����1 ������
            case AnimationType.Attack:
                return Attack2Damage; // ����2 ������
            default:
                return 0; // �⺻������ 0 ��ȯ
        }
    }

    public void Hp_Passive_Skill()
    {
        int ranNum = Random.Range(0, 100);
        if (ranNum < 30) // 30% Ȯ���� HP ����
        {
            Hp += (int)(Hp * 0.4f); // HP 40% ����
        }
    }

    public Sprite[] GetHitPointSprites()
    {
        return _hitPointSprite;
    }

    public void ActivatePassiveSkill()
    {
        // �нú� ��ų �ߵ� �� �� ������ RNG ����
        HeadRNG -= (int)(headDamage * 0.5f); // �Ӹ� ���� RNG ����
        BodyRNG -= (int)(bodyDamage * 0.5f); // ���� ���� RNG ����
        ArmRNG -= (int)(armDamage * 0.5f); // �� ���� RNG ����

        // ���ݷ� ����
        _attackDamage += (int)(AttackDamage * 0.3f); // ���ݷ� 30% ����
    }

    public void Speed_Passive_Skill()
    {
        int ranNum = Random.Range(0, 100);  // 0�� 100 ���̿��� ���� ���� ����
        if (ranNum < 30)  // 30% Ȯ���� ���� �ӵ� ����
        {
            AttackSpeed += 1;  // ���� �ӵ� 1 ����
        }
    }

    // �� ��� ó��
    private void OnDeath()
    {
        Debug.Log("Enemy has died!");
        Destroy(gameObject);
    }
}
