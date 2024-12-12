using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = "Ability/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string itemName;
    
    #region PublicAbilityData
    
    public float attack;
    public float speed;
    public float dodge;
    public float accuracy;
    public float escape;
    public float critical;
    public float criticalAttack;

    public float hp;
    public float currentHp;
    public float maxHp;

    public float hungry;
    public float currentHungry;
    public float maxHungry;
    

    #endregion
    
     
    #region PrivateAbilityData
    
    public float damageDown;
    
    #endregion
}
