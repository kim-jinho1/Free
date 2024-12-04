using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemGrade/Myth", fileName = "MythItemFrame")]
public class RSJ_MythItem : ScriptableObject
{
    public SpriteRenderer _img;
    public string _itemName;
    public string _itemExplain;

    public ItemSort _itemSort;

    [Header("스탯변화모음")]
    #region 스탯변화모음
    public int _Attack;
    public int _Speed;
    public int _DodgePer;
    public int _CriticalPer;
    public float PlusHP;
    public float PlusHunger;
    #endregion
}
