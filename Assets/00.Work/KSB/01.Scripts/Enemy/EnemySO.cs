using UnityEngine;

[CreateAssetMenu(fileName = "SO/Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("EnemyNormalSetting")]
    public int hp;
    public float attackSpeed;
    public int skill1_AttackDamage;
    public int attackSucRate;


    [Header("EnemyDamageSetting")]
    public float BodyDamage;
    public float ArmDamage;
    public float HeadDamage;

    [Header("EnemyProbabilitySetting")]
    public int BodyRNG;
    public int ArmRNG;
    public int HeadRNG;

    [Header("For Boss Enemy")]
    public int skill2_AttackRate;
    public int skill1_AttackRate;
    public int skill2_AttackDamage;

    [Header("Passive_Skill_Rng")]
    public int _attack_Passive_Rng;
    public int _speed_Passive_Rng;


}


