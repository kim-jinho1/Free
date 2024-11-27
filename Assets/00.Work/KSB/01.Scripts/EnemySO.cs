using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO/Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("EnemyNormalSetting")]
    public int Hp;
    public float AttackSpeed;
    public float AttackDamage;
    public int AttackRate;

    [Header("EnemyDamageSetting")]
    public float BodyDamage;
    public float ArmDamage;
    public float HeadDamage;

    [Header("EnemyProbabilitySetting")]
    public int BodyRNG;
    public int ArmRNG;
    public int HeadRNG;

    public (float Damage, int Rng) GetData(AttackPart attackPart)//������ ������ ������
    {
       switch(attackPart)
        {
            case AttackPart.Head:
                return (HeadDamage, HeadRNG);        
            case AttackPart.Body:
                return (BodyDamage, BodyRNG);
            case AttackPart.Arm:
                return (ArmDamage, ArmRNG);
            default:
                Debug.Log("�������� �ʴ� �����Դϴ�");
                return (0, 0);

        }
    }

}

public enum AttackPart
{
    Body,
    Head,
    Arm,
}
