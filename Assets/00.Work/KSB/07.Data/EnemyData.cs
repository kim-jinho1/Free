using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class EnemyData : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private EnemySO enemySO;
    [Header(" About normalSetting")]
    public int hp;
    public float attackDamage;
    public float attackSpeed;
    public int attackSucRate;


    [Header(" About Damage Rate")]
    private int headRNG;
    private int bodyRNG;
    private int armRNG;

    [Header(" About Damage Of Part")]
    private float headDamage;
    private float bodyDamage;
    private float armDamage;


    [Header("For Boss")]
    private int _mainSkillRng;

 

    private void Start()
    {
        hp = enemySO.hp;
        Debug.Log(hp);
        attackDamage = enemySO.attackDamage;
        attackSpeed = enemySO.attackSpeed;
        attackSucRate = enemySO.attackRate;

        headRNG = enemySO.HeadRNG;
        bodyRNG = enemySO.BodyRNG;
        armRNG = enemySO.ArmRNG;

        headDamage = enemySO.HeadDamage;
        bodyDamage = enemySO.BodyDamage;
        armDamage = enemySO.ArmDamage;

        _mainSkillRng = enemySO.MainSkillRng;
    }
    public (float Damage, int Rng) GetData(AttackPart attackPart)//부위별 데미지 데이터
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
                Debug.Log("지원하지 않는 부위입니다");
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

