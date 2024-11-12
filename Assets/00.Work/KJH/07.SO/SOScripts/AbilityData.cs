using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = " Ability/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string itemName;
    
    #region AbilityData
    
    public int attackPower;
    public int hp;
    public int speed;
    public int evasionRate;
    public int accuracy;
    public int escapeRate;
    public int criticalStrikeRate;
    
    #endregion
    
    #region AbilityDataImage
    
    public Sprite attackPowerImage;
    public Sprite hpImage;
    public Sprite speedImage;
    public Sprite evasionRateImage;
    public Sprite accuracyImage;
    public Sprite escapeRateRateImage;
    public Sprite criticalStrikeRateImage;
    
    #endregion
}
