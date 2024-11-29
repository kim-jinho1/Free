using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO/Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("EnemyNormalSetting")]
    public int hp;
    public float attackSpeed;
    public float attackDamage;
    public int attackRate;


    [Header("EnemyDamageSetting")]
    public float BodyDamage;
    public float ArmDamage;
    public float HeadDamage;

    [Header("EnemyProbabilitySetting")]
    public int BodyRNG;
    public int ArmRNG;
    public int HeadRNG;

    [Header("For Boss Enemy")]
    public int MainSkillRng;
    public int attackDamage2;

}


