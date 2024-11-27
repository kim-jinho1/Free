using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum itemType { Equip, Using, Healing }
public enum equipType { None, Sword }
[CreateAssetMenu(menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public Sprite ItemImage;
    public itemType itemType;
    public equipType equipType = equipType.None;

    [Header("Effect_Equip")]
    public float AttackRateUp;
    public float HealthRateUp;
    public float SpeedRateUp;
    public float RatioRateUp;

    [Header("Slot")]
    public int MaxDuplicateValue;
}
