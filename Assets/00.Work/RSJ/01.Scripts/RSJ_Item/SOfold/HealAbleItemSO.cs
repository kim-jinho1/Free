using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO/HealAble", fileName = "HealItem")]
public class HealAbleItemSO : ScriptableObject
{
    [Header("Item Info")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public ItemGrade Grade;

    public float HealPercent; // ü�� ����
    public float HungerPercent; // ����� ��ġ ����
}
