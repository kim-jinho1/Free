using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO/EquipAble", fileName = "EquipItem")]
public class EquipAbleItemSO : ScriptableObject
{
    [Header("Item Info")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public ItemGrade Grade;

    #region 스탯변화
    public int Attack; // 공격력
    public int Speed; // 속도
    public float Critical; // 치명타율
    public float Dodge; // 회피율
    public float PlusHP; // 최대 HP 증가률
    public float PlusHunger; // 최대 배고픔 증가률
    #endregion
}
