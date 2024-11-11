using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewAbilityData", menuName = " Ability/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public int price;
    public int durability;
}
