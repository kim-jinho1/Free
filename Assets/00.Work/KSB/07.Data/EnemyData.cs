using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private EnemySO enemySO;

    [Header("About normalSetting")]
    private int _hp;
    private float _attackDamage;
    private float _attackSpeed;
    private int _attackSucRate;
    public bool _isStunned;

    [Header("About Damage Rate")]
    private int headRNG;
    private int bodyRNG;
    private int armRNG;

    [Header("About Damage Of Part")]
    private float headDamage;
    private float bodyDamage;
    private float armDamage;

    [Header("For Boss")]
    private int _mainSkillRng;

    // Properties
    public int Hp
    {
        get => _hp;
        set => _hp = Mathf.Max(0, value); // Ensure HP is not less than 0
    }

    public float AttackDamage
    {
        get
        {
            return _attackDamage;
        }
        set
        {
            if (value < 0)
            {
                _attackDamage = 0;
            }
            else
            {
                _attackDamage = value;
            }
        }

    }
    /* ���� �İ� ������ ���ϸ��� �÷��̾�� ���ʹ��� AttackSpeed��
    ���ؼ� ���߿� ���� ���� ������ ������ ���� �İ� ������ �����ϰ�
    �׸��� ���߿� ������ reverse ���������� �̰ɷ� ������ �� ����*/
    public float AttackSpeed
    {
        get
        {
            return _attackSpeed;
        }
        set
        {
            if (value < 0)
            {
                _attackDamage = 0;
            }
            else
            {
                _attackDamage = value;
            }
        }
    }

    public int AttackSucRate
    {
        get
        {
            return _attackSucRate;
        }
        set
        {
            if (value < 0)
            {
                _attackSucRate = 0;
            }
            else
            {
                _attackSucRate = value;
            }
        }
    }



    private void Start()
    {
        Hp = enemySO.hp;
        Debug.Log(Hp);
        AttackDamage = enemySO.attackDamage;
        AttackSpeed = enemySO.attackSpeed;
        AttackSucRate = enemySO.attackRate;

        headRNG = enemySO.HeadRNG;
        bodyRNG = enemySO.BodyRNG;
        armRNG = enemySO.ArmRNG;

        headDamage = enemySO.HeadDamage;
        bodyDamage = enemySO.BodyDamage;
        armDamage = enemySO.ArmDamage;

        _mainSkillRng = enemySO.MainSkillRng;
    }

    public (float Damage, int Rng) GetData(AttackPart attackPart)
    {
        switch (attackPart)
        {
            case AttackPart.Head:
                return (headDamage, headRNG);
            case AttackPart.Body:
                return (bodyDamage, bodyRNG);
            case AttackPart.Arm:
                return (armDamage, armRNG);
            default:
                Debug.Log("�������� �ʴ� �����Դϴ�");
                return (0, 0);
        }
    }

    public int GetBossMainSkillRng()
    {
        return _mainSkillRng;
    }
}

public enum AttackPart
{
    Body,
    Head,
    Arm
}
