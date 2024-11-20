using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum itemType { Equip, Using, Healing }
[CreateAssetMenu(menuName = "SO/Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public Sprite ItemImage;
    public itemType itemType;

    [Header("Effect")]
    public float AttackRateUp;
    public float HealthRateUp;
    public float SpeedRateUp;
    public float RatioRateUp;

    [Header("Slot")]
    public int DuplicateValue;
}
