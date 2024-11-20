using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = " Ability/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string itemName;
    
    #region AbilityData
    
    public float attack;
    public float speed;
    public float dodge;
    public float accuracy;
    public float escape;
    public float critical;
    public float criticalAttack;

    public float hp;
    public float CurrentHp;
    public float maxHp;

    public float Hungry;
    public float CurrnetHungry;
    public float MaxHungry;

    #endregion
}
