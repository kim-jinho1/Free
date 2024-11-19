using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = " Ability/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string itemName;
    
    #region AbilityData
    
    public float attackPower;
    public float hp;
    public float speed;
    public float evasionRate;
    public float accuracy;
    public float escapeRate;
    public float criticalStrikeRate;
    public float CriticalDamage;
    
    #endregion
    
}
