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
    public ItemGrade itemGrade;
    public equipType equipType = equipType.None;
    public ItemSort itemSort;

    [Header("Effect_Equip")]
    public float AttackUp;
    public float CriticalUp;
    public float CriticalDamageUp;
    public float HealthRateUp;
    public float SpeedRateUp;
    public float DodgeRateUp;
    public float HungerRateUp;

    [Header("Use_Etc")]
    public float Damage;


    [Header("Slot")]
    public int MaxDuplicateValue;
}
