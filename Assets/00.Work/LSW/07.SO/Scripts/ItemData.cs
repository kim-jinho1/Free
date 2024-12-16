using UnityEngine;

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

    [Header("Effect_Equip")]
    public float AttackUp;
    public float CriticalUp;
    public float HealthRateUp;
    public float SpeedRateUp;
    public float DodgeRateUp;
    public float HungerRateUp;

    [Header("Slot")]
    public int MaxDuplicateValue;
}
