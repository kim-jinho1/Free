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
    public bool _isStunned;

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
    private int _mainAttackRng;
    private int _mainAttackDamage;
    private void Awake()
    {
        _fullHp = enemySO.hp;
        Hp = enemySO.hp;
       
      
        Attack_Passive_Rng = enemySO._attack_Passive_Rng;
        Speed_Passive_Rng = enemySO._speed_Passive_Rng;
     
        AttackDamage = enemySO.attackDamage;
        AttackSpeed = enemySO.attackSpeed;
        AttackSucRate = enemySO.attackRate;

        HeadRNG = enemySO.HeadRNG;
        BodyRNG = enemySO.BodyRNG;
        ArmRNG = enemySO.ArmRNG;

        headDamage = enemySO.HeadDamage;
        bodyDamage = enemySO.BodyDamage;
        armDamage = enemySO.ArmDamage;

        _mainAttackRng = enemySO.MainSkillRng;
    }

  
    public int Hp
    {
        get => _hp;
        
        set
        {
            if (value < 0)
            {
                _attackDamage = 0;
            }
            else if(value > _fullHp)
            {
                _attackDamage = _fullHp;
            }
            else
            {
                _hp = value;
            }
        }
    }

    public int HeadRNG
    {
        get
        {
            return _headRNG;
        }
        set
        {
            if (value < 0)
            {
                _headRNG = 0;
            }
            else if(value > 100)
            {
                _headRNG = 100;
            }
            else
            {
                _headRNG = value;
            }
        }

    }

    public int ArmRNG
    {
        get
        {
            return _armRNG;
        }
        set
        {
            if (value < 0)
            {
                _armRNG = 0;
            }
            else if (value > 100)
            {
                _armRNG = 100;
            }
            else
            {
                _armRNG = value;
            }
        }

    }
    public int BodyRNG
    {
        get
        {
            return _bodyRNG;
        }
        set
        {
            if (value < 0)
            {
                _bodyRNG = 0;
            }
            else if (value > 100)
            {
                _bodyRNG = 100;
            }
            else
            {
                _bodyRNG = value;
            }
        }

    }
    public int AttackDamage
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

    public  int MainAttackDamage
    {
        get
        {
            return _mainAttackDamage;
        }
        set
        {
            if (value < 0)
            {
                _mainAttackDamage = 0;
            }
            else
            {
                _mainAttackDamage = value;
            }
        }

    }
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
                _attackSpeed = 0;
            }
            else
            {
                _attackSpeed = value;
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
            else if (value > 100)
            {
                _attackSucRate = 100;
            }
            else
            {
                _attackSucRate = value;
            }
        }
    }


    public int Attack_Passive_Rng
    {
        get
        {
            return _attack_Passive_Rng;
        }
        set
        {
            if(value < 0)
            {
                _attack_Passive_Rng = 0;
            }
            else if(value>100)
            {
                _attack_Passive_Rng = 100;
            }
            else
            {
                _attack_Passive_Rng = value;
            }
        }
    }

    public int Speed_Passive_Rng
    {
        get
        {
            return _speed_Passive_Rng;
        }
        set
        {
            if (value < 0)
            {
                _speed_Passive_Rng = 0;
            }
            else if (value > 100)
            {
                _speed_Passive_Rng = 100;
            }
            else
            {
                _speed_Passive_Rng = value;
            }
        }
    }
    public void ActivatePassiveSkill()
    {
       
        HeadRNG -= (int)(headDamage * 0.5f);
        print(HeadRNG);
        BodyRNG -= (int)(_bodyRNG * 0.5f);
        print(BodyRNG);
        ArmRNG -= (int)(_armRNG * 0.5f);
        print(ArmRNG);
        _attackDamage += (int)(AttackDamage * 0.3f);
        print(_attackDamage);
    }
    public void Speed_Passive_Skill()
    {
       int ranNum = Random.Range(0, 100);
        if(ranNum<30)
        {
            AttackSpeed += 1;
        }
    }
    public void Hp_Passive_Skill()
    {
        int ranNum = Random.Range(0, 100);
        if (ranNum < 30)
        {
            Hp += (int)(Hp * 0.4f);
        }
    }
    public (float Damage, int Rng) GetData(AttackPart attackPart)//부위별 데미지,성공확률 가져올때 호출하세요
    {
        switch (attackPart)
        {
            case AttackPart.Head:
                return (headDamage, HeadRNG);
            case AttackPart.Body:
                return (bodyDamage, BodyRNG);
            case AttackPart.Arm:
                return (armDamage, ArmRNG);
            default:
                Debug.Log("지원하지 않는 부위입니다");
                return (0, 0);
        }
    }

    public int GetDamage(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.Attack2:
                return AttackDamage;
            case AnimationType.Attack:
                return MainAttackDamage;
            default:
                return 0;
        }
    }
    public int GetBossMainSkillRng()
    {
        return _mainAttackRng;
    }


}

public enum AttackPart
{
    Body,
    Head,
    Arm
}


